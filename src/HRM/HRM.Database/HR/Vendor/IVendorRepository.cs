using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<VendorModel> FindByIdAsync(long id);

        Task<Grid<VendorGridModel>> GridAsync(VendorGridParameterModel paramters);

        Task<bool> SaveAsync(Vendor model, bool isCreate);

        Task<bool> DeleteAsync(Vendor model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
