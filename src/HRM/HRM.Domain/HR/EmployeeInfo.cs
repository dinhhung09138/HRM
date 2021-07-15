using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;
using HRM.Domain.Common;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thong tin cá nhân
    /// </summary>
    public class EmployeeInfo : Entity<long>
    {
        public EmployeeInfo(
            long employeeId,
            string fullName,
            Gender gender,
            DateTime? dateOfBirth,
            long? maritalStatusId,
            long? religionId,
            long? ethnicityId,
            long? nationalityId,
            long? academicLevelId,
            long? professionalQualificationId,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            MaritalStatusId = maritalStatusId;
            ReligionId = religionId;
            EthnicityId = ethnicityId;
            NationalityId = nationalityId;
            AcademicLevelId = academicLevelId;
            ProfessionalQualificationId = professionalQualificationId;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [MaxLength(70)]
        public string FullName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public long? MaritalStatusId { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public long? ReligionId { get; set; }

        public Religion Religion { get; set; }

        public long? EthnicityId { get; set; }

        public Ethnicity Ethnicity { get; set; }

        public long? NationalityId { get; set; }

        public Nationality Nationality { get; set; }

        //TODO
        public long? AcademicLevelId { get; set; }

        public long? ProfessionalQualificationId { get; set; }

        public ProfessionalQualification ProfessionalQualification { get; set; }

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
