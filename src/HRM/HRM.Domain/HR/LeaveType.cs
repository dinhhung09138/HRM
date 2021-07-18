using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Loại phép nghỉ (Thai sản, không lương,...)
    /// </summary>
    public class LeaveType : Entity<long>
    {
        public LeaveType(
            string code,
            string name,
            int numOfDay,
            bool isDeductible,
            string description,
            int precedence,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            Code = code;
            Name = name;
            NumOfDay = numOfDay;
            IsDeductible = isDeductible;
            Description = description;
            Precedence = precedence;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [MaxLength(10)]
        [Required]
        public string Code { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumOfDay { get; set; }

        [Required]
        public bool IsDeductible { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int Precedence { get; set; }

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

        public virtual List<EmployeeLeave> EmployeeLeaves { get; set; }
    }
}
