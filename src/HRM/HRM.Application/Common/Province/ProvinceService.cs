using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;
using HRM.Infrastructure.Extension;
using DotNetCore.Results;
using System.Threading.Tasks;
using HRM.Infrastructure.Services;
using HRM.Database;
using DotNetCore.Objects;

namespace HRM.Application.Common
{
    public class ProvinceService : IProvinceService
    {
        private readonly string _cacheKey = "province";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly IProvinceFactory _provinceFactory;
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            IProvinceFactory provinceFactory,
            IProvinceRepository provinceRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _provinceFactory = provinceFactory;
            _provinceRepository = provinceRepository;
        }


        public async Task<IResult> FindByIdAsync(long id)
        {
            try
            {
                var item = await _provinceRepository.FindByIdAsync(id);

                return Result<ProvinceModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> GridAsync(ProvinceGridParameterModel paramters)
        {
            try
            {
                var grid = await _provinceRepository.GridAsync(paramters);

                return Result<Grid<ProvinceGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> SaveAsync(ProvinceModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(ProvinceModel model)
        {
            try
            {
                var md = await _provinceRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.ItemNotFound);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _provinceRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(ProvinceModel model)
        {
            var validation = await new CreateProvinceModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _provinceFactory.Create(model);

            await _provinceRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(ProvinceModel model)
        {
            var md = await _provinceRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.ItemNotFound);
            }

            var validation = await new UpdateProvinceModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _provinceFactory.Update(model);

            await _provinceRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

    }
}
