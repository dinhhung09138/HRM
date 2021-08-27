
namespace HRM.Model.Common
{
    public sealed class CreateMaritalStatusModelValidator : MaritalStatusValidator
    {
        public CreateMaritalStatusModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
