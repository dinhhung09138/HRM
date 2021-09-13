using HRM.Constant.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class EmployeeInfoModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public long EmployeeId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public Gender Gender { get; set; }

        public long? NationalityId { get; set; }

        public string NationalityIdValue { get; set; }

        public long? EthnicityId { get; set; }

        public string EthnicityIdValue { get; set; }

        public long? ReligionId { get; set; }

        public string ReligionIdValue { get; set; }

        public long? MaritalStatusId { get; set; }

        public string MaritalStatusIdValue { get; set; }

        public long? ProfessionalQualificationId { get; set; }

        public string ProfessionalQualificationIdValue { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string IdCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public DateTime IdStartDate { get; set; }

        public DateTime? IdExpireDate { get; set; }

        [MaxLength(20)]
        public string PassportCode { get; set; }

        [Required]
        public DateTime? PassportStartDate { get; set; }

        public DateTime? PassportExpireDate { get; set; }

        [MaxLength(20)]
        public string DriverLicenseCode { get; set; }

        public DateTime? DriverLicenseStartDate { get; set; }

        public DateTime? DriverLicenseExpireDate { get; set; }
    }
}
