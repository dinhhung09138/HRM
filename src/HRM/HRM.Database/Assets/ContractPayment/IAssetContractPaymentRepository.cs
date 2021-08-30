using System;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Assets
{
    public interface IAssetContractPaymentRepository : IRepository<AssetContractPayment>
    {
        Task<AssetContractPaymentModel> FindByIdAsync(long id);

        Task<Grid<AssetContractPaymentGridModel>> GridAsync(AssetContractPaymentGridParameterModel paramters);

        Task<bool> SaveAsync(AssetContractPayment model, bool isCreate);

        Task<bool> DeleteAsync(AssetContractPayment model);
    }
}
