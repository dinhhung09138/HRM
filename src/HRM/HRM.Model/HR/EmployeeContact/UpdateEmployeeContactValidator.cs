using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.HR
{
    public class UpdateEmployeeContactValidator : EmployeeContactValidator
    {
        public UpdateEmployeeContactValidator()
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
