using System;

namespace HRM.Model.HR
{
    public class CreateEmployeeInfoValidator : EmployeeInfoValidator
    {
        public CreateEmployeeInfoValidator()
        {
            EmployeeId();
            IdCode();
            PassportCode();
            DriverLicenseCode();
        }
    }
}
