using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.HR
{
    public class CreateContractTypeModelValidator : ContractTypeValidator
    {
        public CreateContractTypeModelValidator()
        {
            Code();
            Name();
            Description();
            AllowLeaveDate();
            AllowInsurance();
        }
    }
}