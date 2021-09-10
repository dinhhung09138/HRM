using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class CustomerContactModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public long CustomerId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

    }
}
