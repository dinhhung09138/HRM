using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Hình thức khen thưởng
    /// </summary>
    public class Commendation : Entity<long>
    {
        public Commendation(
            string name, 
            string description, 
            CommendationType type, 
            decimal money,
            int precedence, 
            bool isActive, 
            long createBy, 
            DateTime createDate)
        {
            Name = name;
            Description = description;
            Type = type;
            Precedence = precedence;
            Money = money;
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
        public CommendationType Type { get; set; }

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

        public virtual List<EmployeeCommendation> EmployeeCommendations { get; set; }
    }
}
