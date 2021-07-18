using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    public class Discipline : Entity<long>
    {
        public Discipline(
            string name,
            string description,
            decimal money,
            int precedence,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            Name = name;
            Description = description;
            Money = money;
            Precedence = precedence;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;

        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public decimal Money { get; set; }

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

        public virtual List<EmployeeDiscipline> EmployeeDisciplines { get; set; }
    }
}
