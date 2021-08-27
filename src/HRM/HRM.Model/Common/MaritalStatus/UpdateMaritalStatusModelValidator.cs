namespace HRM.Model.Common
{
    public sealed class UpdateMaritalStatusModelValidator : MaritalStatusValidator
    {
        public UpdateMaritalStatusModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
