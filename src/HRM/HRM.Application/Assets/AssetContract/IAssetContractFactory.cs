using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public interface IAssetContractFactory
    {
        AssetContract Create(AssetContractModel model);

        AssetContract Update(AssetContractModel model);
    }
}
