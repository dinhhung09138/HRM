using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Só ngày nghỉ phép của nhân viên hàng năm
    /// </summary>
    public class EmployeeLeaveSetting : Entity<long>
    {
        public EmployeeLeaveSetting(
            long employeeId,
            int year,
            float numOfDay,
            float dayUsed,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            Year = year;
            NumOfDay = numOfDay;
            DayUsed = dayUsed;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public float NumOfDay { get; set; }

        [Required]
        public float DayUsed { get; set; }

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
