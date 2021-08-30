using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetAssetLiquidationRepository : IRepository<AssetLiquidation>
    {
        Task<AssetLiquidationModel> FindByIdAsync(long id);

        Task<Grid<AssetLiquidationGridModel>> GridAsync(AssetLiquidationGridParameterModel paramters);

        Task<bool> SaveAsync(AssetLiquidation model, bool isCreate);

        Task<bool> DeleteAsync(AssetLiquidation model);
    }
}
