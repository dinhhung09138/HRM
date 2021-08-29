
namespace HRM.Model.Assets
{
    public sealed class CreateAssetFixingModelValidator : AssetFixingValidator
    {
        public CreateAssetFixingModelValidator()
        {
            AssetId();
            FixingDate();
            VendorId();
            Note();
        }
    }
}
