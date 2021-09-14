using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;
using HRM.Domain.Common;

namespace HRM.Domain.HR
{
    public class EmployeeInfo : Entity<long>
    {
        public EmployeeInfo(
            long id,
            long employeeId,
            DateTime? dateOfBirth,
            Gender gender,
            long? nationalityId,
            long? ethnicityId,
            long? religionId,
            long? maritalStatusId,
            long? professionalQualificationId,
            string idCode,
            DateTime idStartDate,
            DateTime? idExpireDate,
            string passportCode,
            DateTime? passportStartDate,
            DateTime? passportExpireDate,
            string driverLicenseCode,
            DateTime? driverLicenseStartDate,
            DateTime? driverLicenseExpireDate,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            EmployeeId = employeeId;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            NationalityId = nationalityId;
            EthnicityId = ethnicityId;
            ReligionId = religionId;
            MaritalStatusId = maritalStatusId;
            ProfessionalQualificationId = professionalQualificationId;
            IdCode = idCode;
            IdStartDate = idStartDate;
            IdExpireDate = idExpireDate;
            PassportCode = passportCode;
            PassportStartDate = passportStartDate;
            PassportExpireDate = passportExpireDate;
            DriverLicenseCode = driverLicenseCode;
            DriverLicenseStartDate = driverLicenseStartDate;
            DriverLicenseExpireDate = driverLicenseExpireDate;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public long? NationalityId { get; set; }

        public Nationality Nationality { get; set; }

        public long? EthnicityId { get; set; }

        public Ethnicity Ethnicity { get; set; }

        public long? ReligionId { get; set; }

        public Religion Religion { get; set; }

        public long? MaritalStatusId { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public long? ProfessionalQualificationId { get; set; }

        public ProfessionalQualification ProfessionalQualification { get; set; }

        [MaxLength(20)]
        [Required]
        public string IdCode { get; set; }

        [Required]
        public DateTime IdStartDate { get; set; }

        public DateTime? IdExpireDate { get; set; }

        [MaxLength(20)]
        public string PassportCode { get; set; }

        public DateTime? PassportStartDate { get; set; }

        public DateTime? PassportExpireDate { get; set; }

        [MaxLength(20)]
        public string DriverLicenseCode { get; set; }

        public DateTime? DriverLicenseStartDate { get; set; }

        public DateTime? DriverLicenseExpireDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public long CreateBy { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public long? UpdateBy { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public byte[] RowVersion { get; set; }
    }
}
