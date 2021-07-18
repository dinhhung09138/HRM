using FluentValidation;

namespace HRM.Model.Common
{
    public abstract class WardValidator : AbstractValidator<WardModel>
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

        public void DistrictId()
        {
            RuleFor(m => m.DistrictId).NotNull();
        }

        public void Precedence()
        {
            RuleFor(m => m.Precedence).NotNull();
        }

        public void IsActive()
        {
            RuleFor(m => m.IsActive).NotNull();
        }
    }
}
