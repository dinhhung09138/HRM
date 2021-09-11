using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<VendorModel> FindByIdAsync(long id);

        Task<Grid<VendorGridModel>> GridAsync(VendorGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Vendor model, bool isCreate);

        Task<bool> DeleteAsync(Vendor model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
