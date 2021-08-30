using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetFixingRepository : IRepository<AssetFixing>
    {
        Task<AssetFixingModel> FindByIdAsync(long id);

        Task<Grid<AssetFixingGridModel>> GridAsync(AssetFixingGridParameterModel paramters);

        Task<bool> SaveAsync(AssetFixing model, bool isCreate);

        Task<bool> DeleteAsync(AssetFixing model);
    }
}
