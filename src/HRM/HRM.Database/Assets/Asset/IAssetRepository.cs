using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Task<bool> IsExistingCode(long? id, string code);

        Task<AssetModel> FindByIdAsync(long id);

        Task<Grid<AssetGridModel>> GridAsync(AssetGridParameterModel paramters);

        Task<bool> SaveAsync(Asset model, bool isCreate);

        Task<bool> DeleteAsync(Asset model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
