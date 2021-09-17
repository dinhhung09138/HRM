using System;

namespace HRM.Model.HR
{
    public class UpdateReligionModelValidator : ReligionValidator
    {
        public UpdateReligionModelValidator()
        {
            Id();
            Name();
        }
    }
}
