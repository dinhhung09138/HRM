using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IEmployeeWorkingStatusService
    {
        Task<IResult<EmployeeWorkingStatusModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<EmployeeWorkingStatusGridModel>>> GridAsync(EmployeeWorkingStatusGridParameterModel paramters);

        Task<IResult> SaveAsync(EmployeeWorkingStatusModel model, bool isCreate);

        Task<IResult> DeleteAsync(EmployeeWorkingStatusModel model);
    }
}
