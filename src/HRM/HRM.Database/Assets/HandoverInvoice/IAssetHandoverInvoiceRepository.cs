using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetHandoverInvoiceRepository : IRepository<AssetHandoverInvoice>
    {
        Task<AssetHandoverInvoiceModel> FindByIdAsync(long id);

        Task<Grid<AssetHandoverInvoiceGridModel>> GridAsync(AssetHandoverInvoiceGridParameterModel paramters);

        Task<bool> SaveAsync(AssetHandoverInvoice model, bool isCreate);

        Task<bool> DeleteAsync(AssetHandoverInvoice model);
    }
}
