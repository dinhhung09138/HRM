using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using DotNetCore.Objects;
using HRM.Infrastructure.Extension;
using HRM.Infrastructure.Services;

namespace HRM.Application.Common
{
    public sealed class CertificatedService : ICertificatedService
    {
        private readonly string _cacheKey = "certificated";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly ICertificatedFactory _certificatedFactory;
        private readonly ICertificatedRepository _certificatedRepository;

        public CertificatedService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            ICertificatedFactory certificatedFactory,
            ICertificatedRepository certificatedRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _certificatedFactory = certificatedFactory;
            _certificatedRepository = certificatedRepository;
        }

        public async Task<IResult<CertificatedModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _certificatedRepository.FindByIdAsync(id);

                return Result<CertificatedModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<CertificatedModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<CertificatedGridModel>>> GridAsync(CertificatedGridParameterModel paramters)
        {
            try
            {
                var grid = await _certificatedRepository.GridAsync(paramters);
                return Result<Grid<CertificatedGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(CertificatedModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(CertificatedModel model)
        {
            try
            {
                var md = await _certificatedRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _certificatedRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(CertificatedModel model)
        {
            var validation = await new CreateCertificatedModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _certificatedFactory.Create(model);

            await _certificatedRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(CertificatedModel model)
        {
            var md = await _certificatedRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateCertificatedModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _certificatedFactory.Update(model);

            await _certificatedRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

    }
}
