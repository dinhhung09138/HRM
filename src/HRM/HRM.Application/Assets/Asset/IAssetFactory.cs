using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public interface IAssetFactory
    {
        Asset Create(AssetModel model);

        Asset Update(AssetModel model);
    }
}
