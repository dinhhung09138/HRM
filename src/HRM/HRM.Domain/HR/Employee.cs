using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.Assets;
using HRM.Domain.System;

namespace HRM.Domain.HR
{
    public class Employee : Entity<long>
    {
        public Employee(
            string employeeCode,
            string fullName,
            long branchId,
            long? departmentId,
            long? positionId,
            long? jobPositionId,
            long? managerId,
            string email,
            string phone,
            string phoneExt,
            string fax,
            long? employeeWorkingStatusId,
            DateTime? probationDate, 
            DateTime? startWorkingDate, 
            DateTime? resignDate,
            string badgeCardNumber, 
            DateTime? dateApplyBadge,
            string fingerSignNumber,
            DateTime? dateApplyFingerSign,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeCode = employeeCode;
            FullName = fullName;
            BranchId = branchId;
            DepartmentId = departmentId;
            PositionId = positionId;
            JobPositionId = jobPositionId;
            ManagerId = managerId;
            Email = email;
            Phone = phone;
            PhoneExt = phoneExt;
            Fax = fax;
            EmployeeWorkingStatusId = employeeWorkingStatusId;

            ProbationDate = probationDate;
            StartWorkingDate = startWorkingDate;
            ResignDate = resignDate;
            BadgeCardNumber = badgeCardNumber;
            DateApplyBadge = dateApplyBadge;
            FingerSignNumber = fingerSignNumber;
            DateApplyFingerSign = dateApplyFingerSign;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [MaxLength(15)]
        [Required]
        public string EmployeeCode { get; set; }

        [MaxLength(70)]
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// TODO, need to add Branch where (ho chi minh, ha noi,...)
        /// </summary>
        [Required]
        public long BranchId { get; set; }

        public long? DepartmentId { get; set; }

        public Department Department { get; set; }

        public long? PositionId { get; set; }

        public Position Position { get; set; }

        /// <summary>
        /// TODO Vij tri cong viec, cong nhan, Senior Dev, QC
        /// Can tao bangr JobPosition
        /// </summary>
        public long? JobPositionId { get; set; }

        public long? ManagerId { get; set; }

        public Employee Manager { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(10)]
        public string PhoneExt { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        public long? EmployeeWorkingStatusId { get; set; }

        public EmployeeWorkingStatus EmployeeWorkingStatus { get; set; }

        public DateTime? ProbationDate { get; set; }

        public DateTime? StartWorkingDate { get; set; }

        public DateTime? ResignDate { get; set; }

        [MaxLength(10)]
        public string BadgeCardNumber { get; set; }

        public DateTime? DateApplyBadge { get; set; }

        [MaxLength(10)]
        public string FingerSignNumber { get; set; }

        public DateTime? DateApplyFingerSign { get; set; }

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

        public virtual SystemUser SystemUser { get; set; }

        public virtual List<EmployeeBank> EmployeeBanks { get; set; }

        public virtual List<EmployeeCertificate> EmployeeCertificates { get; set; }

        public virtual List<EmployeeCommendation> EmployeeCommendations { get; set; }

        public virtual List<EmployeeCommendation> EmployeeCommendationApproveds { get; set; }

        public virtual List<EmployeeCommendation> EmployeeCommendationProposers { get; set; }

        public virtual List<EmployeeContract> EmployeeContractProcesses { get; set; }

        public virtual List<EmployeeContact> EmployeeContacts { get; set; }

        public virtual List<EmployeeContract> EmployeeContracts { get; set; }

        public virtual List<EmployeeDependency> EmployeeDependencies { get; set; }

        public virtual List<EmployeeDiscipline> EmployeeDisciplines { get; set; }

        public virtual List<EmployeeDiscipline> EmployeeDisciplineProposers { get; set; }

        public virtual List<EmployeeDiscipline> EmployeeDisciplineApproveds { get; set; }

        public virtual List<EmployeeEducation> EmployeeEducations { get; set; }

        public virtual EmployeeInfo EmployeeInfo { get; set; }

        public virtual List<EmployeeLeave> EmployeeLeaves { get; set; }

        public virtual List<EmployeeLeave> EmployeeLeaveLineManagers { get; set; }

        public virtual List<EmployeeLeave> EmployeeLeaveApprovers { get; set; }

        public virtual List<EmployeeLeaveSetting> EmployeeLeaveSettings { get; set; }

        public virtual List<EmployeeRelationship> EmployeeRelationships { get; set; }

        public virtual List<AssetHandoverInvoice> AssetHandoverInvoiceHandovers { get; set; }

        public virtual List<AssetHandoverInvoice> AssetHandoverInvoiceReceivers { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
