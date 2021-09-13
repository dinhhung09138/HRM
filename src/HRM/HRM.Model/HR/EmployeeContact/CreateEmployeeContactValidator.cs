using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.HR
{
    public class CreateEmployeeContactValidator : EmployeeContactValidator
    {
        public CreateEmployeeContactValidator()
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
