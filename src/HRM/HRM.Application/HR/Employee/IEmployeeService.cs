using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IEmployeeService
    {
        Task<IResult<EmployeeModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<EmployeeGridModel>>> GridAsync(EmployeeGridParameterModel paramters);

        Task<IResult<EmployeeModel>> SaveAsync(EmployeeModel model, bool isCreate);

        Task<IResult> DeleteAsync(EmployeeModel model);
    }
}
