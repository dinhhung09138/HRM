﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Hình thức đào tạo
    /// </summary>
    public class ModelOfStudy : Entity<long>
    {
        public ModelOfStudy(
            string name,
            int precedence,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            Name = name;
            Precedence = precedence;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [MaxLength(100)]
        [Required]
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

        public virtual List<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
