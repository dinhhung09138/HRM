using System;
using HRM.Model;
using HRM.Model.Assets;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.Assets
{
    public interface IAssetTypeService
    {
        Task<IResult<AssetTypeModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<AssetTypeGridModel>>> GridAsync(AssetTypeGridParameterModel paramters);

        Task<IResult> SaveAsync(AssetTypeModel model, bool isCreate);

        Task<IResult> DeleteAsync(AssetTypeModel model);
    }
}
