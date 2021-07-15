using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Ngày nghỉ của nhân viên
    /// </summary>
    public class EmployeeLeave : Entity<long>
    {
        public EmployeeLeave(
            long employeeId,
            long leaveTypeId,
            LeaveStatus leaveStatus,
            DateTime startTime,
            DateTime endTime,
            long lineManagerId,
            string carbonCopy,
            long? approverId,
            string reason,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            LeaveTypeId = leaveTypeId;
            LeaveStatus = leaveStatus;
            StartTime = startTime;
            EndTime = endTime;
            LineManagerId = lineManagerId;
            CarbonCopy = carbonCopy;
            ApproverId = approverId;
            Reason = reason;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }

        [Required]
        public LeaveStatus LeaveStatus { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public long LineManagerId { get; set; }

        public Employee LineManager { get; set; }

        [MaxLength(500)]
        public string CarbonCopy { get; set; }

        [Required]
        public long? ApproverId { get; set; }

        public Employee Approver { get; set; }

        [MaxLength(250)]
        public string Reason { get; set; }

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
