using FluentValidation;

namespace HRM.Model.HR
{
    public abstract class CustomerContactValidator : AbstractValidator<CustomerContactModel>
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
        }

        public void Position()
        {
            RuleFor(m => m.Position).MaximumLength(100);
        }

        public void IsActive()
        {
            RuleFor(m => m.IsActive).NotNull();
        }
    }
}
