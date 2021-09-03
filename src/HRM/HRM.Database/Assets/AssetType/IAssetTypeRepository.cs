using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.Assets
{
    public interface IAssetTypeRepository : IRepository<AssetType>
    {
        Task<AssetTypeModel> FindByIdAsync(long id);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<Grid<AssetTypeGridModel>> GridAsync(AssetTypeGridParameterModel paramters);

        Task<bool> SaveAsync(AssetType model, bool isCreate);

        Task<bool> DeleteAsync(AssetType model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
