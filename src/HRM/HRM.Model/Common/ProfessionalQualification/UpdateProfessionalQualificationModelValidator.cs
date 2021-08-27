namespace HRM.Model.Common
{
    public sealed class UpdateProfessionalQualificationModelValidator : ProfessionalQualificationValidator
    {
        public UpdateProfessionalQualificationModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
