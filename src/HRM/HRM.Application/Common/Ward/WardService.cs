using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;
using HRM.Infrastructure.Extension;
using DotNetCore.Results;
using System.Threading.Tasks;
using HRM.Database;
using HRM.Infrastructure.Services;
using DotNetCore.Objects;

namespace HRM.Application.Common
{
    public class WardService : IWardService
    {
        private readonly string _cacheKey = "ward";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly IWardFactory _wardFactory;
        private readonly IWardRepository _wardRepository;

        public WardService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            IWardFactory wardFactory,
            IWardRepository wardRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _wardFactory = wardFactory;
            _wardRepository = wardRepository;
        }


        public async Task<IResult> FindByIdAsync(long id)
        {
            try
            {
                var item = await _wardRepository.FindByIdAsync(id);

                return Result<WardModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> GridAsync(WardGridParameterModel paramters)
        {
            try
            {
                var grid = await _wardRepository.GridAsync(paramters);

                return Result<Grid<WardGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> SaveAsync(WardModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(WardModel model)
        {
            try
            {
                var md = await _wardRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _wardRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(WardModel model)
        {
            var validation = await new CreateWardModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _wardFactory.Create(model);

            await _wardRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(WardModel model)
        {
            var md = await _wardRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateWardModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _wardFactory.Update(model);

            await _wardRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

    }
}
