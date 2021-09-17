using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class ReligionModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
