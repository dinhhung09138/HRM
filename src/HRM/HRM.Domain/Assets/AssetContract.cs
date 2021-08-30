using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.HR;

namespace HRM.Domain.Assets
{
    public class AssetContract : Entity<long>
    {
        public AssetContract(
            long id,
            string code,
            long vendorId,
            DateTime? signDate,
            DateTime? liquidationDate,
            decimal totalCost,
            string notes,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Code = code;
            VendorId = vendorId;
            SignDate = signDate;
            LiquidationDate = liquidationDate;
            TotalCost = totalCost;
            Notes = notes;
            IsActive = isActive;
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

        public DateTime? SignDate { get; set; }

        public DateTime? LiquidationDate { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Payment { get; set; }

        public decimal ResidualValue { get; set; }

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

        public virtual List<AssetContractPayment> AssetContractPayments { get; set; }

        public virtual List<AssetContractDetail> AssetContractDetails { get; set; }
    }
}
