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
    public class SchoolService : ISchoolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly ISchoolFactory _schoolFactory;
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            ISchoolFactory schoolFactory,
            ISchoolRepository schoolRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _schoolFactory = schoolFactory;
            _schoolRepository = schoolRepository;
        }

        public async Task<IResult<SchoolModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _schoolRepository.FindByIdAsync(id);

                return Result<SchoolModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<SchoolModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<SchoolGridModel>>> GridAsync(SchoolGridParameterModel paramters)
        {
            try
            {
                var grid = await _schoolRepository.GridAsync(paramters);
                return Result<Grid<SchoolGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(SchoolModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(SchoolModel model)
        {
            try
            {
                var md = await _schoolRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _schoolRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(SchoolModel model)
        {
            var validation = await new CreateSchoolModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _schoolFactory.Create(model);

            await _schoolRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(SchoolModel model)
        {
            var md = await _schoolRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateSchoolModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _schoolFactory.Update(model);

            await _schoolRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(SchoolModel model)
        {
            if (await _schoolRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
