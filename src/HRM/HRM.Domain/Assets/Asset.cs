using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Constant.Enums;
using HRM.Domain.HR;

namespace HRM.Domain.Assets
{
    public class Asset : Entity<long>
    {
        public Asset(
            long id,
            string code,
            string name,
            string serialNumber,
            long assetTypeId,
            long vendorId,
            decimal cost,
            decimal fixingCost,
            decimal mantenanceCost,
            DateTime? buyingDate,
            DateTime? warrantyExpiryDate,
            DateTime? liquidationDate,
            string notes,
            AssetStatus assetStatus,
            bool isAllowBorrow,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Code = code;
            Name = name;
            SerialNumber = serialNumber;
            AssetTypeId = assetTypeId;
            VendorId = vendorId;
            Cost = cost;
            FixingCost = fixingCost;
            MantenanceCost = mantenanceCost;
            BuyingDate = buyingDate;
            WarrantyExpiryDate = warrantyExpiryDate;
            LiquidationDate = liquidationDate;
            Notes = notes;
            AssetStatus = assetStatus;
            IsAllowBorrow = isAllowBorrow;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [Required]
        public long AssetTypeId { get; set; }

        public AssetType AssetType { get; set; }

        [Required]
        public long VendorId { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public decimal FixingCost { get; set; }

        public decimal MantenanceCost { get; set; }

        public DateTime? BuyingDate { get; set; }

        public DateTime? WarrantyExpiryDate { get; set; }

        public DateTime? LiquidationDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public AssetStatus AssetStatus { get; set; }

        public bool IsAllowBorrow { get; set; } = false;

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

        public virtual List<AssetFixing> AssetFixings { get; set; }

        public virtual List<AssetHandoverInvoiceDetail> AssetHandoverInvoiceDetails { get; set; }

        public virtual List<AssetLiquidationDetail> AssetLiquidationDetails { get; set; }

    }
}
