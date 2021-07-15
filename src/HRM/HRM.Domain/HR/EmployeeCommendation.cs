using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thông tin khen thưởng của nhân viên
    /// </summary>
    public class EmployeeCommendation : Entity<long>
    {
        public EmployeeCommendation(
            long employeeId,
            long commendationId,
            DateTime date,
            string comment,
            long proposerId,
            DateTime proposeDate,
            CommendationApproveStatus approvedStatus,
            long? approvedBy,
            DateTime? approvedDate,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            CommendationId = commendationId;
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

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long CommendationId { get; set; }

        public Commendation Commendation { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public long ProposerId { get; set; }

        public Employee Proposer { get; set; }

        public DateTime ProposeDate { get; set; }

        public CommendationApproveStatus ApprovedStatus { get; set; }

        public long? ApprovedBy { get; set; }

        public Employee Approver { get; set; }

        public DateTime? ApprovedDate { get; set; }

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
