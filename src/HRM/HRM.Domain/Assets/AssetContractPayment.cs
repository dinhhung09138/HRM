using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.Assets
{
    public class AssetContractPayment : Entity<long>
    {
        public AssetContractPayment(
            long id,
            long assetContractId,
            decimal payment,
            DateTime? paymentDate,
            string notes,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            AssetContractId = assetContractId;
            Payment = payment;
            PaymentDate = paymentDate;
            Notes = notes;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        public long AssetContractId { get; set; }

        public AssetContract AssetContract { get; set; }

        [Required]

        public decimal Payment { get; set; }

        public DateTime? PaymentDate { get; set; }

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
