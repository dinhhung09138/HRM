using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<CustomerModel> FindByIdAsync(long id);

        Task<Grid<CustomerGridModel>> GridAsync(CustomerGridParameterModel paramters);

        Task<bool> SaveAsync(Customer model, bool isCreate);

        Task<bool> DeleteAsync(Customer model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
