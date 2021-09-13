using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> FindByIdAsync(long id);

        Task<Grid<EmployeeGridModel>> GridAsync(EmployeeGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Employee model, bool isCreate);

        Task<bool> DeleteAsync(Employee model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
