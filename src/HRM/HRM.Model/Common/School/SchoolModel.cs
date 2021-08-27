using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Common
{
    public sealed class SchoolModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
