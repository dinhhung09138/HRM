﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRM.Constant;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.Common
{
    public sealed class CertificatedModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
