
namespace HRM.Model.HR
{
    public sealed class CreateBranchModelValidator : BranchValidator
    {
        public CreateBranchModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
