using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.Assets
{
    public class AssetLiquidationDetail : Entity<long>
    {
        public AssetLiquidationDetail(
            long id,
            long assetLiquidationId,
            long assetId,
            string notes)
        {
            Id = id;
            AssetLiquidationId = assetLiquidationId;
            AssetId = assetId;
            Notes = notes;
        }

        public long AssetLiquidationId { get; set; }

        public AssetLiquidation AssetLiquidation { get; set; }

        public long AssetId { get; set; }

        public Asset Asset { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
