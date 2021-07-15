using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thông tin kỷ luật nhân viên
    /// </summary>
    public class EmployeeDiscipline : Entity<long>
    {
        public EmployeeDiscipline(
            long employeeId,
            long disciplineId,
            DateTime date,
            string comment,
            long proposerId,
            DateTime proposeDate,
            DisciplineApproveStatus approvedStatus,
            long? approvedBy,
            DateTime? approvedDate,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            DisciplineId = disciplineId;
            Date = date;
            Comment = comment;
            ProposerId = proposerId;
            ProposeDate = proposeDate;
            ApprovedStatus = approvedStatus;
            ApprovedBy = approvedBy;
            ApprovedDate = approvedDate;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Money { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public long DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        [Required]
        public long ProposerId { get; set; }

        public Employee Proposer { get; set; }

        [Required]
        public DateTime ProposeDate { get; set; }

        public long? ApprovedBy { get; set; }

        public Employee Approver { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public DisciplineApproveStatus ApprovedStatus { get; set; }

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
