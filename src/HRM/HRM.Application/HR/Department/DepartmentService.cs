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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentFactory _departmentFactory;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(
            IUnitOfWork unitOfWork,
            IDepartmentFactory departmentFactory,
            IDepartmentRepository departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _departmentFactory = departmentFactory;
            _departmentRepository = departmentRepository;
        }

        public async Task<IResult<DepartmentModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _departmentRepository.FindByIdAsync(id);

                return Result<DepartmentModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<DepartmentModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<DepartmentGridModel>>> GridAsync(DepartmentGridParameterModel paramters)
        {
            try
            {
                var grid = await _departmentRepository.GridAsync(paramters);
                return Result<Grid<DepartmentGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _departmentRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(DepartmentModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(DepartmentModel model)
        {
            try
            {
                var md = await _departmentRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _departmentRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(DepartmentModel model)
        {
            var validation = await new CreateDepartmentModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _departmentFactory.Create(model);

            await _departmentRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(DepartmentModel model)
        {
            var md = await _departmentRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateDepartmentModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _departmentFactory.Update(model);

            await _departmentRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(DepartmentModel model)
        {
            if (await _departmentRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
