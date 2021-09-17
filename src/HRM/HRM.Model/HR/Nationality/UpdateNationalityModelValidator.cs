using System;

namespace HRM.Model.HR
{
    public class UpdateNationalityModelValidator : NationalityValidator
    {
        public UpdateNationalityModelValidator()
        {
            Id();
            Name();
        }
    }
}
