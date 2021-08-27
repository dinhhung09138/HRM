
namespace HRM.Model.Common
{
    public sealed class CreateProfessionalQualificationModelValidator : ProfessionalQualificationValidator
    {
        public CreateProfessionalQualificationModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
