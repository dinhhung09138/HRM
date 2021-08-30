namespace HRM.Model.Assets
{
    public sealed class UpdateAssetModelValidator : AssetValidator
    {
        public UpdateAssetModelValidator()
        {
            Id();
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
