using System;

namespace HRM.Model.HR
{
    public class CreateEmployeeValidator : EmployeeValidator
    {
        public CreateEmployeeValidator()
        {
            EmployeeCode();
            FullName();
            BranchId();
            Email();
            Phone();
            PhoneExt();
            Fax();
            BadgeCardNumber();
            FingerSignNumber();
        }
    }
}
