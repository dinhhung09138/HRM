using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class LeaveTypeModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public int NumOfDay { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public bool IsDeductible { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

    }
}
