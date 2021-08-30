
namespace HRM.Model.Assets
{
    public sealed class CreateAssetModelValidator : AssetValidator
    {
        public CreateAssetModelValidator()
        {
            Code();
            Name();
            SerialNumber();
            AssetTypeId();
            VendorId();
            Notes();
            IsActive();
        }
    }
}
