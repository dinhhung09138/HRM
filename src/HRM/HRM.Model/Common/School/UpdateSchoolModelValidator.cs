namespace HRM.Model.Common
{
    public sealed class UpdateSchoolModelValidator : SchoolValidator
    {
        public UpdateSchoolModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
