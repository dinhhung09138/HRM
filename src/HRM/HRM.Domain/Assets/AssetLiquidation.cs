using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.HR;

namespace HRM.Domain.Assets
{
    public class AssetLiquidation : Entity<long>
    {
        public AssetLiquidation(
            long id,
            string code,
            long vendorId,
            DateTime liquidationDate,
            decimal totalCost,
            int totalDivices,
            string notes,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Code = code;
            VendorId = vendorId;
            LiquidationDate = liquidationDate;
            TotalCost = totalCost;
            TotalDivices = totalDivices;
            Notes = notes;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]

        public long VendorId { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        public DateTime LiquidationDate { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public int TotalDivices { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

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

        public virtual List<AssetLiquidationDetail> AssetLiquidationDetails { get; set; }
    }
}
