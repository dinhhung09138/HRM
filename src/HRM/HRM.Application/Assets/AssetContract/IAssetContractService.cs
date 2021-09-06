using System;
using HRM.Model;
using HRM.Model.Assets;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Assets
{
    public interface IAssetContractService
    {
        Task<IResult<AssetContractModel>> FindByIdAsync(long id);

        Task<IResult<Grid<AssetContractGridModel>>> GridAsync(AssetContractGridParameterModel paramters);

        Task<IResult> SaveAsync(AssetContractModel model, bool isCreate);

        Task<IResult> DeleteAsync(AssetContractModel model);
    }
}
