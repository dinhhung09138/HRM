using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.HR;

namespace HRM.Domain.Common
{
    public class ProfessionalQualification : Entity<long>
    {
        public ProfessionalQualification(
            long id,
            string name,
            int precedence,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Name = name;
            Precedence = precedence;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

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

        public virtual List<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
