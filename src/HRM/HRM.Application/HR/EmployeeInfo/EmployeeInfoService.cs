using System;
using HRM.Database.HR;
using HRM.Model.HR;
using DotNetCore.EntityFrameworkCore;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;

namespace HRM.Application.HR
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeInfoFactory _employeeInfoFactory;
        private readonly IEmployeeInfoRepository _employeeInfoRepository;

        public EmployeeInfoService(
            IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository,
            IEmployeeInfoFactory employeeInfoFactory,
            IEmployeeInfoRepository employeeInfoRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _employeeInfoFactory = employeeInfoFactory;
            _employeeInfoRepository = employeeInfoRepository;
        }

        public async Task<IResult<EmployeeInfoModel>> FindByEmployeeIdAsync(long employeeId)
        {
            try
            {
                var item = await _employeeInfoRepository.FindByEmployeeIdAsync(employeeId);

                return Result<EmployeeInfoModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<EmployeeInfoModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<EmployeeInfoModel>> SaveAsync(EmployeeInfoModel model, bool isCreate)
        {
            try
            {
                var employee = await _employeeRepository.FindByIdAsync(model.EmployeeId);

                if (employee == null)
                {
                    return Result<EmployeeInfoModel>.Fail(Constant.Message.EMPLOYEE_NOT_FOUND);
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
                return Result<EmployeeInfoModel>.Fail(ex.Message);
            }
        }

        private async Task<IResult<EmployeeInfoModel>> Create(EmployeeInfoModel model)
        {
            var validation = await new CreateEmployeeInfoModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result<EmployeeInfoModel>.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _employeeInfoFactory.Create(model);

            await _employeeInfoRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            model.Id = md.Id;

            return Result<EmployeeInfoModel>.Success(model);
        }

        private async Task<IResult<EmployeeInfoModel>> Update(EmployeeInfoModel model)
        {
            var md = await _employeeInfoRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result<EmployeeInfoModel>.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return Result<EmployeeInfoModel>.Fail(checkCurrentVersionResponse.Message);
            }

            var validation = await new UpdateEmployeeInfoModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result<EmployeeInfoModel>.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _employeeInfoFactory.Update(model);

            await _employeeInfoRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            model.Id = md.Id;

            return Result<EmployeeInfoModel>.Success(model);
        }

        private async Task<IResult> CheckCurrentVersion(EmployeeInfoModel model)
        {
            if (await _employeeInfoRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
