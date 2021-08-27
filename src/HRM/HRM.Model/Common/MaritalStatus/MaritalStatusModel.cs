using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Common
{
    public sealed class MaritalStatusModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
