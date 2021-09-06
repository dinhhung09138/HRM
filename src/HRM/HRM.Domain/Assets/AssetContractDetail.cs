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
            long assetTypeId,
            decimal price,
            float quantity,
            float vat,
            decimal total,
            string notes
            )
        {
            Id = id;
            AssetContractId = assetContractId;
            AssetTypeId = assetTypeId;
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
        public long AssetTypeId { get; set; }

        public AssetType AssetType { get; set; }

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
