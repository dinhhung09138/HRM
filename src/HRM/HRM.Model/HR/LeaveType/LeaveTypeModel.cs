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
        [Range(1, 100, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "OneTo100")]
        public int NumOfDay { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public bool IsDeductible { get; set; } = false;

        [MaxLength(255)]
        public string Description { get; set; }

    }
}
