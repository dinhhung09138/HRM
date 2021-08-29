namespace HRM.Model.Assets
{
    public sealed class UpdateAssetFixingModelValidator : AssetFixingValidator
    {
        public UpdateAssetFixingModelValidator()
        {
            Id();
            AssetId();
            FixingDate();
            VendorId();
            Note();
        }
    }
}
