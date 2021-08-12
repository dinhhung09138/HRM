using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.System
{
    public class SystemPage : Entity<long>
    {
        public SystemPage(
            long id,
            string name,
            string moduleName,
            int modulePrecedence,
            int precedence,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Name = name;
            ModuleName = moduleName;
            ModulePrecedence = modulePrecedence;
            Precedence = precedence;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [MaxLength(70)]
        public string ModuleName { get; set; }

        [Required]
        public int ModulePrecedence { get; set; }

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

        public virtual List<SystemFunction> SystemFunctions { get; set; }
    }
}
