using System;
using HRM.Model;
using HRM.Model.Assets;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Assets
{
    public interface IAssetContractDetailService
    {
        Task<IResult<AssetContractDetailModel>> FindByIdAsync(long id);

        Task<IResult> SaveAsync(AssetContractDetailModel model);

        Task<IResult> DeleteAsync(AssetContractDetailModel model);
    }
}
