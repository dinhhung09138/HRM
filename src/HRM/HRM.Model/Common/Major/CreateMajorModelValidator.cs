using System;

namespace HRM.Model.Common
{
    public sealed class CreateMajorModelValidator : MajorValidator
    {
        public CreateMajorModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
