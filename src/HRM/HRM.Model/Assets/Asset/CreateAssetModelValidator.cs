
namespace HRM.Model.Assets
{
    public sealed class CreateAssetModelValidator : AssetValidator
    {
        public CreateAssetModelValidator()
        {
            Code();
            SerialNumber();
            AssetTypeId();
            VendorId();
            Notes();
            IsActive();
        }
    }
}
