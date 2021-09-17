using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class RankingModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
