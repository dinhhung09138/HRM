using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IDepartmentService
    {
        Task<IResult<DepartmentModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<DepartmentGridModel>>> GridAsync(DepartmentGridParameterModel paramters);

        Task<IResult> SaveAsync(DepartmentModel model, bool isCreate);

        Task<IResult> DeleteAsync(DepartmentModel model);
    }
}
