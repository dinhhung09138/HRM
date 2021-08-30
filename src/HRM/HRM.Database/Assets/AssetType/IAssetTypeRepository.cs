using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetTypeRepository : IRepository<AssetType>
    {
        Task<AssetTypeModel> FindByIdAsync(long id);

        Task<Grid<AssetTypeGridModel>> GridAsync(AssetTypeGridParameterModel paramters);

        Task<bool> SaveAsync(AssetType model, bool isCreate);

        Task<bool> DeleteAsync(AssetType model);
    }
}
