using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetHandoverInvoiceDetailRepository : IRepository<AssetHandoverInvoiceDetail>
    {
        Task<bool> SaveAsync(AssetHandoverInvoiceDetail model, bool isCreate);

        Task<bool> DeleteAsync(AssetHandoverInvoiceDetail model);
    }
}
