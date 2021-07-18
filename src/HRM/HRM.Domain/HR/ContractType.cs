using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Loại hợp đồng
    /// </summary>
    public class ContractType : Entity<long>
    {
        public ContractType(
            string code,
            string name,
            string description,
            bool allowInsurance,
            bool allowLeaveDate,
            int precedence,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            Code = code;
            Name = name;
            Description = description;
            Precedence = precedence;
            AllowInsurance = allowInsurance;
            AllowLeaveDate = allowLeaveDate;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;

        }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public bool AllowInsurance { get; set; }

        [Required]
        public bool AllowLeaveDate { get; set; }

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

        public virtual List<EmployeeContract> EmployeeContracts { get; set; }
    }
}
