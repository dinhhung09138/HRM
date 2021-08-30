namespace HRM.Model.Assets
{
    public sealed class UpdateAssetLiquidationModelValidator : AssetLiquidationValidator
    {
        public UpdateAssetLiquidationModelValidator()
        {
            Id();
            Code();
            VendorId();
            LiquidationDate();
            Note();
        }
    }
}
