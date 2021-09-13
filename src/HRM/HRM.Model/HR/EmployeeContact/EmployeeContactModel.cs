using HRM.Constant.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class EmployeeContactModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public long EmployeeId { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(15)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Skyper { get; set; }

        [MaxLength(20)]
        public string Zalo { get; set; }

        [MaxLength(200)]
        public string Facebook { get; set; }

        [MaxLength(200)]
        public string LinkedIn { get; set; }

        [MaxLength(200)]
        public string Twitter { get; set; }

        [MaxLength(200)]
        public string Github { get; set; }

        [MaxLength(20)]
        public string Whatsapp { get; set; }

        [MaxLength(250)]
        public string TemporaryAddress { get; set; }

        public long? TemporaryWardId { get; set; }

        public string TemporaryWardIdValue { get; set; }

        public long? TemporaryDistrictId { get; set; }

        public string TemporaryDistrictIdValue { get; set; }

        public long? TemporaryProvinceId { get; set; }

        public string TemporaryProvinceIdValue { get; set; }

        [MaxLength(250)]
        public string PermanentAddress { get; set; }
        
        public long? PermanentWardId { get; set; }

        public string PermanentWardIdValue { get; set; }

        public long? PermanentDistrictId { get; set; }

        public string PermanentDistrictIdValue { get; set; }

        public long? PermanentProvinceId { get; set; }

        public string PermanentProvinceIdValue { get; set; }

        [MaxLength(70)]
        public string EmergencyName { get; set; }

        [MaxLength(20)]
        public string EmergencyPhone { get; set; }

        [MaxLength(50)]
        public string EmergencyEmail { get; set; }

    }
}
