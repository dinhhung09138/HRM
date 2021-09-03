using System;
using HRM.Model;
using HRM.Model.Assets;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Assets
{
    public interface IAssetService
    {
        Task<IResult<AssetModel>> FindByIdAsync(long id);

        Task<IResult<Grid<AssetGridModel>>> GridAsync(AssetGridParameterModel paramters);

        Task<IResult> SaveAsync(AssetModel model, bool isCreate);

        Task<IResult> DeleteAsync(AssetModel model);
    }
}
