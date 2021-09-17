using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface ILeaveTypeService
    {
        Task<IResult<LeaveTypeModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<LeaveTypeGridModel>>> GridAsync(LeaveTypeGridParameterModel paramters);

        Task<IResult> SaveAsync(LeaveTypeModel model, bool isCreate);

        Task<IResult> DeleteAsync(LeaveTypeModel model);
    }
}
