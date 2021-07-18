namespace HRM.Model.Common
{
    public sealed class UpdateWardModelValidator : WardValidator
    {
        public UpdateWardModelValidator()
        {
            Id();
            Name();
            DistrictId();
            Precedence();
            IsActive();
        }
    }
}
