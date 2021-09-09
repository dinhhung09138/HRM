using FluentValidation;

namespace HRM.Model.HR
{
    public class VendorValidator : AbstractValidator<VendorModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(100);
        }

        public void Phone()
        {
            RuleFor(m => m.Phone).MaximumLength(20);
        }

        public void Email()
        {
            RuleFor(m => m.Email).MaximumLength(50);
            RuleFor(m => m.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        }

        public void Address()
        {
            RuleFor(m => m.Address).MaximumLength(100);
        }

        public void TaxCode()
        {
            RuleFor(m => m.TaxCode).MaximumLength(20);
        }

        public void Notes()
        {
            RuleFor(m => m.Notes).MaximumLength(500);
        }

        public void IsActive()
        {
            RuleFor(m => m.IsActive).NotNull();
        }
    }
}
