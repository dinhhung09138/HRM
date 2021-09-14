using System;

namespace HRM.Model.HR
{
    public class CreateEmployeeModelValidator : EmployeeValidator
    {
        public CreateEmployeeModelValidator()
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
