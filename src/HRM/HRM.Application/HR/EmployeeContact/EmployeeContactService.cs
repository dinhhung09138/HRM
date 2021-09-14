using System;
using HRM.Database.HR;
using HRM.Model.HR;
using DotNetCore.EntityFrameworkCore;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;

namespace HRM.Application.HR
{
    public class EmployeeContactService : IEmployeeContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeContactFactory _employeeContactFactory;
        private readonly IEmployeeContactRepository _employeeContactRepository;

        public EmployeeContactService(
            IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository,
            IEmployeeContactFactory employeeContactFactory,
            IEmployeeContactRepository employeeContactRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _employeeContactFactory = employeeContactFactory;
            _employeeContactRepository = employeeContactRepository;
        }

        public async Task<IResult<EmployeeContactModel>> FindByEmployeeIdAsync(long employeeId)
        {
            try
            {
                var item = await _employeeContactRepository.FindByEmployeeIdAsync(employeeId);

                return Result<EmployeeContactModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<EmployeeContactModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<EmployeeContactModel>> SaveAsync(EmployeeContactModel model, bool isCreate)
        {
            try
            {
                var employee = await _employeeRepository.FindByIdAsync(model.EmployeeId);

                if (employee == null)
                {
                    return Result<EmployeeContactModel>.Fail(Constant.Message.EMPLOYEE_NOT_FOUND);
                }

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
                return Result<EmployeeContactModel>.Fail(ex.Message);
            }
        }

        private async Task<IResult<EmployeeContactModel>> Create(EmployeeContactModel model)
        {
            var validation = await new CreateEmployeeContactModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result<EmployeeContactModel>.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _employeeContactFactory.Create(model);

            await _employeeContactRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            model.Id = md.Id;

            return Result<EmployeeContactModel>.Success(model);
        }

        private async Task<IResult<EmployeeContactModel>> Update(EmployeeContactModel model)
        {
            var md = await _employeeContactRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result<EmployeeContactModel>.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return Result<EmployeeContactModel>.Fail(checkCurrentVersionResponse.Message);
            }

            var validation = await new UpdateEmployeeContactModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result<EmployeeContactModel>.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _employeeContactFactory.Update(model);

            await _employeeContactRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            model.Id = md.Id;

            return Result<EmployeeContactModel>.Success(model);
        }

        private async Task<IResult> CheckCurrentVersion(EmployeeContactModel model)
        {
            if (await _employeeContactRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
