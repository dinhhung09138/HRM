using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetContractDetailExpression
    {
        public static Expression<Func<AssetContractDetail, AssetContractDetailModel>> FindByIdAsync => m => new AssetContractDetailModel()
        {
            Id = m.Id,
            AssetContractId = m.AssetContractId,
            AssetId = m.AssetId,
            Price = m.Price,
            Quantity = m.Quantity,
            Vat = m.Vat,
            Total = m.Total,
            Notes = m.Notes,
        };
    }
}
