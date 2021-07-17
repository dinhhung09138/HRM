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

namespace HRM.Application.Common
{
    public class CertificatedService : ICertificatedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICertificatedFactory _certificatedFactory;
        private readonly ICertificatedRepository _certificatedRepository;

        public CertificatedService(
            IUnitOfWork unitOfWork,
            ICertificatedFactory certificatedFactory,
            ICertificatedRepository certificatedRepository)
        {
            _unitOfWork = unitOfWork;
            _certificatedFactory = certificatedFactory;
            _certificatedRepository = certificatedRepository;
        }

        public async Task<IResult> FindByIdAsync(long id)
        {
            try
            {
                var item = await _certificatedRepository.FindByIdAsync(id);

                return Result<CertificatedModel>.Success(item);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> GridAsync(CertificatedGridParameterModel paramters)
        {
            try
            {
                var grid = await _certificatedRepository.GridAsync(paramters);

                return Result<Grid<CertificatedGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
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
        }

        public async Task<IResult> DeleteAsync(CertificatedModel model)
        {
            try
            {
                var md = _certificatedFactory.Update(model);
                md.Deleted = true;

                await _certificatedRepository.DeleteAsync(md);

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

            return Result.Success();
        }

        private async Task<IResult> Update(CertificatedModel model)
        {
            var validation = await new UpdateCertificatedModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _certificatedFactory.Update(model);

            await _certificatedRepository.SaveAsync(md, true);

            return Result.Success();
        }

    }
}
