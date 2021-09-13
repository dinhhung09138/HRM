using FluentValidation;

namespace HRM.Model.HR
{
    public class EmployeeValidator : AbstractValidator<EmployeeModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void EmployeeCode()
        {
            RuleFor(m => m.EmployeeCode).NotEmpty().NotNull();
            RuleFor(m => m.EmployeeCode).MaximumLength(15);
        }

        public void FullName()
        {
            RuleFor(m => m.FullName).NotEmpty().NotNull();
            RuleFor(m => m.FullName).MaximumLength(70);
        }

        public void BranchId()
        {
            RuleFor(m => m.BranchId).NotEmpty().NotNull();
        }

        public void Email()
        {
            RuleFor(m => m.Email).MaximumLength(50);
            RuleFor(m => m.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        }

        public void Phone()
        {
            RuleFor(m => m.Phone).MaximumLength(20);
        }

        public void PhoneExt()
        {
            RuleFor(m => m.PhoneExt).MaximumLength(10);
        }

        public void Fax()
        {
            RuleFor(m => m.Fax).MaximumLength(20);
        }

        public void BadgeCardNumber()
        {
            RuleFor(m => m.BadgeCardNumber).MaximumLength(20);
        }

        public void FingerSignNumber()
        {
            RuleFor(m => m.FingerSignNumber).MaximumLength(20);
        }

    }
}
