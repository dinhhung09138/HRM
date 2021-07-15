using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.Common;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Các chứng chỉ đào tạo của nhân viên
    /// </summary>
    public class EmployeeCertificate : Entity<long>
    {
        public EmployeeCertificate(
            long employeeId,
            long certificatedId,
            long schoolId,
            int year,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            CertificatedId = certificatedId;
            SchoolId = schoolId;
            Year = year;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long CertificatedId { get; set; }

        public Certificated Certificated { get; set; }

        [Required]
        public long SchoolId { get; set; }

        public School School { get; set; }

        [Required]
        public int Year { get; set; }

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
