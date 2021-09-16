using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IEmployeeWorkingStatusRepository : IRepository<EmployeeWorkingStatus>
    {
        Task<EmployeeWorkingStatusModel> FindByIdAsync(long id);

        Task<Grid<EmployeeWorkingStatusGridModel>> GridAsync(EmployeeWorkingStatusGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(EmployeeWorkingStatus model, bool isCreate);

        Task<bool> DeleteAsync(EmployeeWorkingStatus model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
