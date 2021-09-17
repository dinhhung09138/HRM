using System;
using System.Linq;
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
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILeaveTypeFactory _leaveTypeFactory;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveTypeService(
            IUnitOfWork unitOfWork,
            ILeaveTypeFactory leaveTypeFactory,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _leaveTypeFactory = leaveTypeFactory;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<IResult<LeaveTypeModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _leaveTypeRepository.FindByIdAsync(id);

                return Result<LeaveTypeModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<LeaveTypeModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<LeaveTypeGridModel>>> GridAsync(LeaveTypeGridParameterModel paramters)
        {
            try
            {
                var grid = await _leaveTypeRepository.GridAsync(paramters);
                return Result<Grid<LeaveTypeGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _leaveTypeRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(LeaveTypeModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(LeaveTypeModel model)
        {
            try
            {
                var md = await _leaveTypeRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _leaveTypeRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(LeaveTypeModel model)
        {
            var validation = await new CreateLeaveTypeModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            if (await _leaveTypeRepository.IsExistingCode(model.Id, model.Code))
            {
                return Result.Fail(Constant.Message.CODE_IS_EXISTS);
            }

            var md = _leaveTypeFactory.Create(model);

            await _leaveTypeRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(LeaveTypeModel model)
        {
            var md = await _leaveTypeRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            if (await _leaveTypeRepository.IsExistingCode(model.Id, model.Code))
            {
                return Result.Fail(Constant.Message.CODE_IS_EXISTS);
            }

            var validation = await new UpdateLeaveTypeModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _leaveTypeFactory.Update(model);

            await _leaveTypeRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(LeaveTypeModel model)
        {
            if (await _leaveTypeRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
