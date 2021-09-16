namespace HRM.Model.HR
{
    public sealed class UpdateBranchModelValidator : BranchValidator
    {
        public UpdateBranchModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
