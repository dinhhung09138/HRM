using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    public class Position : Entity<long>
    {
        public Position(
            long id,
            string name,
            string description,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

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

        public virtual List<Employee> Employees { get; set; }
    }
}
