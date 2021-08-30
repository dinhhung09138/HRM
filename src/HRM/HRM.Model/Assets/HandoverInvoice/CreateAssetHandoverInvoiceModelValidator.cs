
namespace HRM.Model.Assets
{
    public sealed class CreateAssetHandoverInvoiceModelValidator : AssetHandoverInvoiceValidator
    {
        public CreateAssetHandoverInvoiceModelValidator()
        {
            Code();
            HandoverBy();
            HandoverDate();
            ReceiveBy();
            Notes();
        }
    }
}
