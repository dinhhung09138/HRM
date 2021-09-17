using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface ILeaveTypeRepository : IRepository<LeaveType>
    {
        Task<LeaveTypeModel> FindByIdAsync(long id);

        Task<Grid<LeaveTypeGridModel>> GridAsync(LeaveTypeGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> IsExistingCode(long? id, string code);

        Task<bool> SaveAsync(LeaveType model, bool isCreate);

        Task<bool> DeleteAsync(LeaveType model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
