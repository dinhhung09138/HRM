using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface ICustomerContactRepository : IRepository<CustomerContact>
    {
        Task<CustomerContactModel> FindByIdAsync(long id);

        Task<Grid<CustomerContactGridModel>> GridAsync(CustomerContactGridParameterModel paramters);

        Task<bool> SaveAsync(CustomerContact model, bool isCreate);

        Task<bool> DeleteAsync(CustomerContact model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
