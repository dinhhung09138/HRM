using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.Common
{
    public sealed class DistrictModel : BaseModel
    {
        public string Name { get; set; }
		
        public long ProvinceId { get; set; }
		
        public string ProvinceName { get; set; }
    }
}
