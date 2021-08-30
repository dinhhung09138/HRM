
namespace HRM.Model.Assets
{
    public sealed class CreateAssetLiquidationModelValidator : AssetLiquidationValidator
    {
        public CreateAssetLiquidationModelValidator()
        {
            Code();
            VendorId();
            LiquidationDate();
            Note();
        }
    }
}
