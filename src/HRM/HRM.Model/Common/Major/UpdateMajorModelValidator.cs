using System;

namespace HRM.Model.Common
{
    public sealed class UpdateMajorModelValidator : MajorValidator
    {
        public UpdateMajorModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
