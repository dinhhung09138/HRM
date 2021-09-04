using System;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Common
{
    public interface IMaritalStatusRepository : IRepository<MaritalStatus>
    {
        Task<MaritalStatusModel> FindByIdAsync(long id);

        Task<Grid<MaritalStatusGridModel>> GridAsync(MaritalStatusGridParameterModel paramters);

        Task<bool> SaveAsync(MaritalStatus model, bool isCreate);

        Task<bool> DeleteAsync(MaritalStatus model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
