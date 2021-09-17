using FluentValidation;

namespace HRM.Model.HR
{
    public class ReligionValidator : AbstractValidator<ReligionModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(50);
        }

    }
}
