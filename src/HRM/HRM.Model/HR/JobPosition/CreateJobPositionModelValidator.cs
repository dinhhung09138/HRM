
namespace HRM.Model.HR
{
    public sealed class CreateJobPositionModelValidator : JobPositionValidator
    {
        public CreateJobPositionModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
