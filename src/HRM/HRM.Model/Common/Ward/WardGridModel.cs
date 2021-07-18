using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.Common
{
    public sealed class WardGridModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string DistrictName { get; set; }

        public string ProvinceName { get; set; }
    }
}
