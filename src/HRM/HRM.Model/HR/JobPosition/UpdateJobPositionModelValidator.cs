namespace HRM.Model.HR
{
    public sealed class UpdateJobPositionModelValidator : JobPositionValidator
    {
        public UpdateJobPositionModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
