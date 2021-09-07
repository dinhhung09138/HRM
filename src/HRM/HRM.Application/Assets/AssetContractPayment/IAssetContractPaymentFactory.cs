using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public interface IAssetContractPaymentFactory
    {
        AssetContractPayment Create(AssetContractPaymentModel model);

        AssetContractPayment Update(AssetContractPaymentModel model);
    }
}
