using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.HR;

namespace HRM.Domain.Assets
{
    public class AssetFixing : Entity<long>
    {
        public AssetFixing(
            long id,
            long assetId,
            DateTime fixingDate,
            decimal cost,
            long vendorId,
            string notes,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            AssetId = assetId;
            FixingDate = fixingDate;
            VendorId = vendorId;
            Cost = cost;
            Notes = notes;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]

        public long AssetId { get; set; }

        public Asset Asset { get; set; }

        [Required]
        public DateTime FixingDate { get; set; }

        [Required]

        public long VendorId { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        public decimal Cost { get; set; }

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
    }
}
