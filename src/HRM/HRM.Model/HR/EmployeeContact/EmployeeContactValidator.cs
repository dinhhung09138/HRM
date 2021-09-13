using FluentValidation;

namespace HRM.Model.HR
{
    public class EmployeeContactValidator : AbstractValidator<EmployeeContactModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void EmployeeId()
        {
            RuleFor(m => m.EmployeeId).NotEmpty().NotNull();
        }

        public void Phone()
        {
            RuleFor(m => m.Phone).MaximumLength(15);
        }

        public void Mobile()
        {
            RuleFor(m => m.Mobile).MaximumLength(15);
        }

        public void Email()
        {
            RuleFor(m => m.Email).MaximumLength(100);
        }

        public void Skyper()
        {
            RuleFor(m => m.Skyper).MaximumLength(50);
        }

        public void Zalo()
        {
            RuleFor(m => m.Zalo).MaximumLength(20);
        }

        public void Facebook()
        {
            RuleFor(m => m.Facebook).MaximumLength(200);
        }

        public void LinkedIn()
        {
            RuleFor(m => m.LinkedIn).MaximumLength(200);
        }

        public void Twitter()
        {
            RuleFor(m => m.Twitter).MaximumLength(200);
        }

        public void Github()
        {
            RuleFor(m => m.Github).MaximumLength(200);
        }

        public void Whatsapp()
        {
            RuleFor(m => m.Whatsapp).MaximumLength(20);
        }

        public void TemporaryAddress()
        {
            RuleFor(m => m.TemporaryAddress).MaximumLength(250);
        }

        public void PermanentAddress()
        {
            RuleFor(m => m.PermanentAddress).MaximumLength(250);
        }

        public void EmergencyName()
        {
            RuleFor(m => m.EmergencyName).MaximumLength(70);
        }

        public void EmergencyPhone()
        {
            RuleFor(m => m.EmergencyPhone).MaximumLength(20);
        }

        public void EmergencyEmail()
        {
            RuleFor(m => m.EmergencyEmail).MaximumLength(20);
        }

    }
}
