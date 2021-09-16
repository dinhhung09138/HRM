using System;
using HRM.Database.HR;
using HRM.Model;
using HRM.Model.HR;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public class EmployeeWorkingStatusService : IEmployeeWorkingStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeWorkingStatusFactory _employeeWorkingStatusFactory;
        private readonly IEmployeeWorkingStatusRepository _employeeWorkingStatusRepository;

        public EmployeeWorkingStatusService(
            IUnitOfWork unitOfWork,
            IEmployeeWorkingStatusFactory employeeWorkingStatusFactory,
            IEmployeeWorkingStatusRepository employeeWorkingStatusRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeWorkingStatusFactory = employeeWorkingStatusFactory;
            _employeeWorkingStatusRepository = employeeWorkingStatusRepository;
        }

        public async Task<IResult<EmployeeWorkingStatusModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _employeeWorkingStatusRepository.FindByIdAsync(id);

                return Result<EmployeeWorkingStatusModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<EmployeeWorkingStatusModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<EmployeeWorkingStatusGridModel>>> GridAsync(EmployeeWorkingStatusGridParameterModel paramters)
        {
            try
            {
                var grid = await _employeeWorkingStatusRepository.GridAsync(paramters);
                return Result<Grid<EmployeeWorkingStatusGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _employeeWorkingStatusRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(EmployeeWorkingStatusModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(EmployeeWorkingStatusModel model)
        {
            try
            {
                var md = await _employeeWorkingStatusRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _employeeWorkingStatusRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(EmployeeWorkingStatusModel model)
        {
            var validation = await new CreateEmployeeWorkingStatusModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _employeeWorkingStatusFactory.Create(model);

            await _employeeWorkingStatusRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(EmployeeWorkingStatusModel model)
        {
            var md = await _employeeWorkingStatusRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateEmployeeWorkingStatusModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _employeeWorkingStatusFactory.Update(model);

            await _employeeWorkingStatusRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(EmployeeWorkingStatusModel model)
        {
            if (await _employeeWorkingStatusRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
