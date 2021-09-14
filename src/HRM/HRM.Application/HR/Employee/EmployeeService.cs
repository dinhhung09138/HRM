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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IEmployeeFactory employeeFactory,
            IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeFactory = employeeFactory;
            _employeeRepository = employeeRepository;
        }

        public async Task<IResult<EmployeeModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _employeeRepository.FindByIdAsync(id);

                return Result<EmployeeModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<EmployeeModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<EmployeeGridModel>>> GridAsync(EmployeeGridParameterModel paramters)
        {
            try
            {
                var grid = await _employeeRepository.GridAsync(paramters);
                return Result<Grid<EmployeeGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _employeeRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult<EmployeeModel>> SaveAsync(EmployeeModel model, bool isCreate)
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
                return Result<EmployeeModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(EmployeeModel model)
        {
            try
            {
                var md = await _employeeRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _employeeRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult<EmployeeModel>> Create(EmployeeModel model)
        {
            var validation = await new CreateEmployeeModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result<EmployeeModel>.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _employeeFactory.Create(model);

            await _employeeRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            model.Id = md.Id;

            return Result<EmployeeModel>.Success(model);
        }

        private async Task<IResult<EmployeeModel>> Update(EmployeeModel model)
        {
            var md = await _employeeRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result<EmployeeModel>.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return Result<EmployeeModel>.Fail(checkCurrentVersionResponse.Message);
            }

            var validation = await new UpdateEmployeeModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result<EmployeeModel>.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _employeeFactory.Update(model);

            await _employeeRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            model.Id = md.Id;

            return Result<EmployeeModel>.Success(model);
        }

        private async Task<IResult> CheckCurrentVersion(EmployeeModel model)
        {
            if (await _employeeRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
