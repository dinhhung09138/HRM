namespace HRM.Model.HR
{
    public sealed class UpdatePositionModelValidator : PositionValidator
    {
        public UpdatePositionModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
