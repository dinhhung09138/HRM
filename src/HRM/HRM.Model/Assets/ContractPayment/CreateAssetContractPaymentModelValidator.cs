
namespace HRM.Model.Assets
{
    public sealed class CreateAssetContractPaymentModelValidator : AssetContractPaymentValidator
    {
        public CreateAssetContractPaymentModelValidator()
        {
            AssetContractId();
            Payment();
            PaymentDate();
            Note();
        }
    }
}
