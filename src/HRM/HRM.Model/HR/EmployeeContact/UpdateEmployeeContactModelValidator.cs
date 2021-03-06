using System;

namespace HRM.Model.HR
{
    public class UpdateEmployeeContactModelValidator : EmployeeContactValidator
    {
        public UpdateEmployeeContactModelValidator()
        {
            Id();
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
