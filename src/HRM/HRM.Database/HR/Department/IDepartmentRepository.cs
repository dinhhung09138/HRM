using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<DepartmentModel> FindByIdAsync(long id);

        Task<Grid<DepartmentGridModel>> GridAsync(DepartmentGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Department model, bool isCreate);

        Task<bool> DeleteAsync(Department model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
