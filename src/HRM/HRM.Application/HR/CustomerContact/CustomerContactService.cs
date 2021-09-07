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

namespace HRM.Application.HR
{
    public sealed class CustomerContactService : ICustomerContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerContactFactory _customerContactFactory;
        private readonly ICustomerContactRepository _customerContactRepository;

        public CustomerContactService(
            IUnitOfWork unitOfWork,
            ICustomerContactFactory customerContactFactory,
            ICustomerContactRepository customerContactRepository)
        {
            _unitOfWork = unitOfWork;
            _customerContactFactory = customerContactFactory;
            _customerContactRepository = customerContactRepository;
        }

        public async Task<IResult<CustomerContactModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _customerContactRepository.FindByIdAsync(id);

                return Result<CustomerContactModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<CustomerContactModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<CustomerContactGridModel>>> GridAsync(CustomerContactGridParameterModel paramters)
        {
            try
            {
                var grid = await _customerContactRepository.GridAsync(paramters);
                return Result<Grid<CustomerContactGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(CustomerContactModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(CustomerContactModel model)
        {
            try
            {
                var md = await _customerContactRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _customerContactRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(CustomerContactModel model)
        {
            var validation = await new CreateCustomerContactModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _customerContactFactory.Create(model);

            await _customerContactRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(CustomerContactModel model)
        {
            var md = await _customerContactRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateCustomerContactModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _customerContactFactory.Update(model);

            await _customerContactRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(CustomerContactModel model)
        {
            if (await _customerContactRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
