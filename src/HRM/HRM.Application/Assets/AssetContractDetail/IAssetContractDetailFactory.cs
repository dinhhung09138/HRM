using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public interface IAssetContractDetailFactory
    {
        AssetContractDetail Create(AssetContractDetailModel model);

    }
}
