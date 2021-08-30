using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetContractRepository : IRepository<AssetContract>
    {
        Task<AssetContractModel> FindByIdAsync(long id);

        Task<Grid<AssetContractGridModel>> GridAsync(AssetContractGridParameterModel paramters);

        Task<bool> SaveAsync(AssetContract model, bool isCreate);

        Task<bool> DeleteAsync(AssetContract model);
    }
}
