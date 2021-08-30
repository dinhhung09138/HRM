using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetLiquidationDetailRepository : IRepository<AssetLiquidationDetail>
    {
        Task<bool> SaveAsync(AssetLiquidationDetail model, bool isCreate);

        Task<bool> DeleteAsync(AssetLiquidationDetail model);
    }
}
