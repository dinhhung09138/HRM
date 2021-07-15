using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.Common;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Băng cấp chuyên môn
    /// </summary>
    public class EmployeeEducation : Entity<long>
    {

        public EmployeeEducation(
            long employeeId,
            long educationId,
            long schoolId,
            long majorId,
            int year,
            long rankingId,
            long modelOfStudyId,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            EducationId = educationId;
            SchoolId = schoolId;
            MajorId = majorId;
            Year = year;
            RankingId = rankingId;
            ModelOfStudyId = modelOfStudyId;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long EducationId { get; set; }

        public Education Education { get; set; }

        [Required]
        public long SchoolId { get; set; }

        public School School { get; set; }

        [Required]
        public long MajorId { get; set; }

        public Major Major { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public long RankingId { get; set; }

        public Ranking Ranking { get; set; }

        [Required]
        public long ModelOfStudyId { get; set; }

        public ModelOfStudy ModelOfStudy { get; set; }

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
