using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;

namespace HRM.Database.HR
{
    public interface IEmployeeContactRepository : IRepository<EmployeeContact>
    {
        Task<EmployeeContactModel> FindByEmployeeIdAsync(long employeeId);

        Task<bool> SaveAsync(EmployeeContact model, bool isCreate);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
