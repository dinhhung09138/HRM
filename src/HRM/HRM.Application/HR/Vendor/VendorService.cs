using System;
using System.Linq;
using HRM.Database.HR;
using HRM.Model;
using HRM.Model.HR;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using HRM.Infrastructure.Services;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public sealed class VendorService : IVendorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVendorFactory _vendorFactory;
        private readonly IVendorRepository _vendorRepository;

        public VendorService(
            IUnitOfWork unitOfWork,
            IVendorFactory vendorFactory,
            IVendorRepository vendorRepository)
        {
            _unitOfWork = unitOfWork;
            _vendorFactory = vendorFactory;
            _vendorRepository = vendorRepository;
        }

        public async Task<IResult<VendorModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _vendorRepository.FindByIdAsync(id);

                return Result<VendorModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<VendorModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<VendorGridModel>>> GridAsync(VendorGridParameterModel paramters)
        {
            try
            {
                var grid = await _vendorRepository.GridAsync(paramters);
                return Result<Grid<VendorGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _vendorRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(VendorModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(VendorModel model)
        {
            try
            {
                var md = await _vendorRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _vendorRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(VendorModel model)
        {
            var validation = await new CreateVendorModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _vendorFactory.Create(model);

            await _vendorRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(VendorModel model)
        {
            var md = await _vendorRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateVendorModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _vendorFactory.Update(model);

            await _vendorRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(VendorModel model)
        {
            if (await _vendorRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
