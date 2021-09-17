using FluentValidation;

namespace HRM.Model.HR
{
    public class RankingValidator : AbstractValidator<RankingModel>
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

    }
}
