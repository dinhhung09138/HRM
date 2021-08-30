﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.Assets;

namespace HRM.Domain.HR
{
    public class Vendor : Entity<long>
    {
        public Vendor(
            long id,
            string name,
            string phone,
            string email,
            string address,
            string taxCode,
            string notes,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            TaxCode = taxCode;
            Notes = notes;
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
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string TaxCode { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

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

        public virtual List<Asset> Assets { get; set; }

        public virtual List<AssetContract> AssetContracts { get; set; }

        public virtual List<AssetFixing> AssetFixings { get; set; }

        public virtual List<AssetLiquidation> AssetLiquidations { get; set; }

    }
}
