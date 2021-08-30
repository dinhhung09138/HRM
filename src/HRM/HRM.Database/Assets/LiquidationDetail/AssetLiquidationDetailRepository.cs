using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;

namespace HRM.Database.Assets
{
    public class AssetLiquidationDetailRepository : EFRepository<AssetLiquidationDetail>, IAssetLiquidationDetailRepository
    {
        public AssetLiquidationDetailRepository(Context context) : base(context) { }

        public async Task<bool> SaveAsync(AssetLiquidationDetail model, bool isCreate)
        {
            if (isCreate == true)
            {
                await AddAsync(model);
            }
            else
            {
                await UpdatePartialAsync(new
                {
                    model.Id,
                    model.AssetLiquidationId,
                    model.AssetId,
                    model.Notes,
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetLiquidationDetail model)
        {
            await DeleteAsync(model);

            return true;
        }
    }
}
