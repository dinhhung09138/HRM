using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetContractDetailRepository : IRepository<AssetContractDetail>
    {
        Task<AssetContractDetailModel> FindByIdAsync(long id);

        Task<bool> SaveAsync(AssetContractDetail model, bool isCreate);

        Task<bool> DeleteAsync(AssetContractDetail model);
    }
}
