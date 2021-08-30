using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.Assets
{
    public class AssetContractDetail : Entity<long>
    {
        public AssetContractDetail(
            long id,
            long assetContractId,
            long assetId,
            decimal price,
            float quantity,
            float vat,
            decimal total,
            string notes
            )
        {
            Id = id;
            AssetContractId = assetContractId;
            AssetId = assetId;
            Price = price;
            Quantity = quantity;
            Vat = vat;
            Total = total;
            Notes = notes;
        }

        [Required]
        public long AssetContractId { get; set; }

        public AssetContract AssetContract { get; set; }

        [Required]
        public long AssetId { get; set; }

        public Asset Asset { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float Vat { get; set; }

        [Required]
        public decimal Total { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
