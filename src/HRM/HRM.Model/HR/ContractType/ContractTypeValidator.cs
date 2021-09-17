using FluentValidation;

namespace HRM.Model.HR
{
    public class ContractTypeValidator : AbstractValidator<ContractTypeModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Code()
        {
            RuleFor(m => m.Code).NotEmpty().NotNull();
            RuleFor(m => m.Code).MaximumLength(10);
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(100);
        }

        public void Description()
        {
            RuleFor(m => m.Description).MaximumLength(250);
        }

        public void AllowInsurance()
        {
            RuleFor(m => m.AllowInsurance).NotEmpty().NotNull();
        }

        public void AllowLeaveDate()
        {
            RuleFor(m => m.AllowLeaveDate).NotEmpty().NotNull();
        }

    }
}
