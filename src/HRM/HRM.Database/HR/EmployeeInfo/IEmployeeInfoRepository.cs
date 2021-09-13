using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;

namespace HRM.Database.HR
{
    public interface IEmployeeInfoRepository
    {
        Task<EmployeeInfoModel> FindByEmployeeIdAsync(long employeeId);

        Task<bool> SaveAsync(EmployeeInfo model, bool isCreate);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
