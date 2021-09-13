using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;

namespace HRM.Database.HR
{
    public interface IEmployeeContactRepository
    {
        Task<EmployeeContactModel> FindByEmployeeIdAsync(long employeeId);

        Task<bool> SaveAsync(EmployeeContact model, bool isCreate);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
