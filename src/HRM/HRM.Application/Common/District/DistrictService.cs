using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;
using HRM.Database;
using HRM.Infrastructure.Services;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using System.Threading.Tasks;
using DotNetCore.Objects;

namespace HRM.Application.Common
{
    public class DistrictService : IDistrictService
    {
        private readonly string _cacheKey = "district";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly IDistrictFactory _districtFactory;
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            IDistrictFactory districtFactory,
            IDistrictRepository districtRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _districtFactory = districtFactory;
            _districtRepository = districtRepository;
        }


        public async Task<IResult> FindByIdAsync(long id)
        {
            try
            {
                var item = await _districtRepository.FindByIdAsync(id);

                return Result<DistrictModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> GridAsync(DistrictGridParameterModel paramters)
        {
            try
            {
                var grid = await _districtRepository.GridAsync(paramters);

                return Result<Grid<DistrictGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> SaveAsync(DistrictModel model, bool isCreate)
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
            finally
            {
                //TODO
                _memoryCache.RemoveFromCache(_cacheKey);
            }
        }

        public async Task<IResult> DeleteAsync(DistrictModel model)
        {
            try
            {
                var md = await _districtRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.ItemNotFound);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _districtRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(DistrictModel model)
        {
            var validation = await new CreateDistrictModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _districtFactory.Create(model);

            await _districtRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(DistrictModel model)
        {
            var md = await _districtRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.ItemNotFound);
            }

            var validation = await new UpdateDistrictModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _districtFactory.Update(model);

            await _districtRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

    }
}
