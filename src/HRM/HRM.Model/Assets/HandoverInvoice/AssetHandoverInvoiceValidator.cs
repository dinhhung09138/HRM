using FluentValidation;

namespace HRM.Model.Assets
{
    public abstract class AssetHandoverInvoiceValidator : AbstractValidator<AssetHandoverInvoiceModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Code()
        {
            RuleFor(m => m.Code).NotEmpty().NotNull();
            RuleFor(m => m.Code).MaximumLength(20);
        }

        public void HandoverBy()
        {
            RuleFor(m => m.HandoverBy).NotEmpty().NotNull();
        }

        public void HandoverDate()
        {
            RuleFor(m => m.HandoverDate).NotEmpty().NotNull();
        }

        public void ReceiveBy()
        {
            RuleFor(m => m.ReceiveBy).NotEmpty().NotNull();
        }

        public void ReceiveDate()
        {
            RuleFor(m => m.ReceiveDate).NotEmpty().NotNull();
        }

        public void Note()
        {
            RuleFor(m => m.Note).MaximumLength(500);
        }

    }
}
