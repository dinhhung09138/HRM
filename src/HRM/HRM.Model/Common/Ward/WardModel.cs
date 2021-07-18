﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.Common
{
    public sealed class WardModel : BaseModel
    {
        public string Name { get; set; }

        public long DistrictId { get; set; }

        public string DistrictName { get; set; }
    }
}
