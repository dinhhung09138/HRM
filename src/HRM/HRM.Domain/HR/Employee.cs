using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Nhân viên
    /// </summary>
    public class Employee : Entity<long>
    {
        public Employee(
            string employeeCode, 
            DateTime? probationDate, 
            DateTime? startWorkingDate, 
            string badgeCardNumber, 
            DateTime? dateApplyBadge,
            string fingerSignNumber,
            DateTime? dateApplyFingerSign,
            string workingEmail,
            string workingPhone,
            long? employeeWorkingStatusId,
            long? currentPositionId,
            long? currentDepartmentId,
            decimal basicSalary,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeCode = employeeCode;
            ProbationDate = probationDate;
            StartWorkingDate = startWorkingDate;
            BadgeCardNumber = badgeCardNumber;
            DateApplyBadge = dateApplyBadge;
            FingerSignNumber = fingerSignNumber;
            DateApplyFingerSign = dateApplyFingerSign;
            WorkingEmail = workingEmail;
            WorkingPhone = workingPhone;
            EmployeeWorkingStatusId = employeeWorkingStatusId;
            CurrentPositionId = currentPositionId;
            CurrentDepartmentId = currentDepartmentId;
            BasicSalary = basicSalary;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [MaxLength(15)]
        [Required]
        public string EmployeeCode { get; set; }

        public DateTime? ProbationDate { get; set; }

        public DateTime? StartWorkingDate { get; set; }

        [MaxLength(10)]
        public string BadgeCardNumber { get; set; }

        public DateTime? DateApplyBadge { get; set; }

        [MaxLength(10)]
        public string FingerSignNumber { get; set; }

        public DateTime? DateApplyFingerSign { get; set; }

        [MaxLength(50)]
        public string WorkingEmail { get; set; }

        [MaxLength(20)]
        public string WorkingPhone { get; set; }

        public long? EmployeeWorkingStatusId { get; set; }

        public EmployeeWorkingStatus EmployeeWorkingStatus { get; set; }

        public long? CurrentPositionId { get; set; }

        public Position Position { get; set; }

        public long? CurrentDepartmentId { get; set; }

        public Department Department { get; set; }

        public decimal BasicSalary { get; set; }

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

        public virtual List<EmployeeBank> EmployeeBanks { get; set; }

        public virtual List<EmployeeCertificate> EmployeeCertificates { get; set; }

        public virtual List<EmployeeCommendation> EmployeeCommendations { get; set; }

        public virtual List<EmployeeContact> EmployeeContacts { get; set; }

        public virtual List<EmployeeContract> EmployeeContracts { get; set; }

        public virtual List<EmployeeDependency> EmployeeDependencys { get; set; }

        public virtual List<EmployeeDiscipline> EmployeeDisciplines { get; set; }

        public virtual List<EmployeeEducation> EmployeeEducations { get; set; }

        public virtual List<EmployeeIdentification> EmployeeIdentifications { get; set; }

        public virtual EmployeeInfo EmployeeInfo { get; set; }

        public virtual List<EmployeeLeaveSetting> EmployeeLeaveSettings { get; set; }

        public virtual List<EmployeeRelationship> EmployeeRelationships { get; set; }
    }
}
