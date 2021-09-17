using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.HR
{
    public class LeaveTypeGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int NumOfDay { get; set; }

        public bool IsDeductible { get; set; }

        public string Description { get; set; }

        public int Precedence { get; set; }

        public bool IsActive { get; set; }
    }
}
