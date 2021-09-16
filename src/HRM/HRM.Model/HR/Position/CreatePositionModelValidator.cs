
namespace HRM.Model.HR
{
    public sealed class CreatePositionModelValidator : PositionValidator
    {
        public CreatePositionModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
