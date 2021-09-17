using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.HR
{
    public class ContractTypeGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool AllowInsurance { get; set; }

        public bool AllowLeaveDate { get; set; }

        public int Precedence { get; set; }

        public bool IsActive { get; set; }
    }
}
