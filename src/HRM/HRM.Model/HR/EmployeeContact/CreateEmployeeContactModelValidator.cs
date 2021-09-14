using System;

namespace HRM.Model.HR
{
    public class CreateEmployeeContactModelValidator : EmployeeContactValidator
    {
        public CreateEmployeeContactModelValidator()
        {
            EmployeeId();
            Phone();
            Mobile();
            Email();
            Skyper();
            Zalo();
            Facebook();
            LinkedIn();
            Twitter();
            Github();
            Whatsapp();
            TemporaryAddress();
            PermanentAddress();
            EmergencyName();
            EmergencyPhone();
            EmergencyEmail();
        }
    }
}
