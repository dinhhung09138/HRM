namespace HRM.Model.Assets
{
    public sealed class UpdateAssetHandoverInvoiceModelValidator : AssetHandoverInvoiceValidator
    {
        public UpdateAssetHandoverInvoiceModelValidator()
        {
            Id();
            Code();
            HandoverBy();
            HandoverDate();
            ReceiveBy();
            Notes();
        }
    }
}
