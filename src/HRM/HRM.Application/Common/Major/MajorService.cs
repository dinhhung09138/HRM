using System;
using System.Linq;
using HRM.Database.Common;
using HRM.Model;
using HRM.Model.Common;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using HRM.Infrastructure.Services;

namespace HRM.Application.Common
{
    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly IMajorFactory _majorFactory;
        private readonly IMajorRepository _majorRepository;

        public MajorService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            IMajorFactory majorFactory,
            IMajorRepository majorRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _majorFactory = majorFactory;
            _majorRepository = majorRepository;
        }

        public async Task<IResult<MajorModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _majorRepository.FindByIdAsync(id);

                return Result<MajorModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<MajorModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<MajorGridModel>>> GridAsync(MajorGridParameterModel paramters)
        {
            try
            {
                var grid = await _majorRepository.GridAsync(paramters);
                return Result<Grid<MajorGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(MajorModel model, bool isCreate)
        {
            try
            {
                if (isCreate == true)
                {
                    return await Create(model);
                }
                else
                {
                    return await Update(model);
                }

            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(MajorModel model)
        {
            try
            {
                var md = await _majorRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _majorRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(MajorModel model)
        {
            var validation = await new CreateMajorModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _majorFactory.Create(model);

            await _majorRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(MajorModel model)
        {
            var md = await _majorRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateMajorModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _majorFactory.Update(model);

            await _majorRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(MajorModel model)
        {
            if (await _majorRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
