using System;
using HRM.Model;
using HRM.Model.Assets;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Assets
{
    public interface IAssetContractPaymentService
    {
        Task<IResult<AssetContractPaymentModel>> FindByIdAsync(long id);

        Task<IResult<Grid<AssetContractPaymentGridModel>>> GridAsync(AssetContractPaymentGridParameterModel paramters);

        Task<IResult> SaveAsync(AssetContractPaymentModel model, bool isCreate);

        Task<IResult> DeleteAsync(AssetContractPaymentModel model);
    }
}
