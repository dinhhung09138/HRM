using System;
using System.Linq;
using HRM.Database.HR;
using HRM.Model;
using HRM.Model.HR;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;

namespace HRM.Application.HR
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            IUnitOfWork unitOfWork,
            ICustomerFactory customerFactory,
            ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public async Task<IResult<CustomerModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _customerRepository.FindByIdAsync(id);

                return Result<CustomerModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<CustomerModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<CustomerGridModel>>> GridAsync(CustomerGridParameterModel paramters)
        {
            try
            {
                var grid = await _customerRepository.GridAsync(paramters);
                return Result<Grid<CustomerGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(CustomerModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(CustomerModel model)
        {
            try
            {
                var md = await _customerRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _customerRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(CustomerModel model)
        {
            var validation = await new CreateCustomerModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _customerFactory.Create(model);

            await _customerRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(CustomerModel model)
        {
            var md = await _customerRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateCustomerModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _customerFactory.Update(model);

            await _customerRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(CustomerModel model)
        {
            if (await _customerRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
