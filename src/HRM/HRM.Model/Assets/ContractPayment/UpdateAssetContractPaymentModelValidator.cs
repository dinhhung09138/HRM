namespace HRM.Model.Assets
{
    public sealed class UpdateAssetContractPaymentModelValidator : AssetContractPaymentValidator
    {
        public UpdateAssetContractPaymentModelValidator()
        {
            Id();
            AssetContractId();
            Payment();
            PaymentDate();
            Note();
        }
    }
}
