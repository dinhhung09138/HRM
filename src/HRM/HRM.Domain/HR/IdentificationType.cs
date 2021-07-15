﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Loại giấy tờ tùy thân (CMND, Bằng lái, Hộ chiếu,...)
    /// </summary>
    public class IdentificationType : Entity<long>
    {
        public IdentificationType(
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

        public virtual List<EmployeeIdentification> EmployeeIdentifications { get; set; }
    }
}
