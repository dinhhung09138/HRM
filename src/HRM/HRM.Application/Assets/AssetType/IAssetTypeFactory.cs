using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public interface IAssetTypeFactory
    {
        AssetType Create(AssetTypeModel model);

        AssetType Update(AssetTypeModel model);
    }
}
