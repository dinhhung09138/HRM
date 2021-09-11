namespace HRM.Model.Assets
{
    public sealed class UpdateAssetModelValidator : AssetValidator
    {
        public UpdateAssetModelValidator()
        {
            Id();
            Code();
            SerialNumber();
            AssetTypeId();
            VendorId();
            Notes();
            IsActive();
        }
    }
}
