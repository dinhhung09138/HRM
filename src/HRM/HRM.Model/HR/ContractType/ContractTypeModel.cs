using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class ContractTypeModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public bool AllowInsurance { get; set; }

        [Required]
        public bool AllowLeaveDate { get; set; }

    }
}
