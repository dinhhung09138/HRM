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
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly IMaritalStatusFactory _maritalStatusFactory;
        private readonly IMaritalStatusRepository _maritalStatusRepository;

        public MaritalStatusService (
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            IMaritalStatusFactory maritalStatusFactory,
            IMaritalStatusRepository maritalStatusRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _maritalStatusFactory = maritalStatusFactory;
            _maritalStatusRepository = maritalStatusRepository;
        }

        public async Task<IResult<MaritalStatusModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _maritalStatusRepository.FindByIdAsync(id);

                return Result<MaritalStatusModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<MaritalStatusModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<MaritalStatusGridModel>>> GridAsync(MaritalStatusGridParameterModel paramters)
        {
            try
            {
                var grid = await _maritalStatusRepository.GridAsync(paramters);
                return Result<Grid<MaritalStatusGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(MaritalStatusModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(MaritalStatusModel model)
        {
            try
            {
                var md = await _maritalStatusRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _maritalStatusRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(MaritalStatusModel model)
        {
            var validation = await new CreateMaritalStatusModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _maritalStatusFactory.Create(model);

            await _maritalStatusRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(MaritalStatusModel model)
        {
            var md = await _maritalStatusRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateMaritalStatusModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _maritalStatusFactory.Update(model);

            await _maritalStatusRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
