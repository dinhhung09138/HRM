namespace HRM.Model.Assets
{
    public sealed class UpdateAssetContractModelValidator : AssetContractValidator
    {
        public UpdateAssetContractModelValidator()
        {
            Id();
            Code();
            VendorId();
            SignDate();
            Notes();
        }
    }
}
