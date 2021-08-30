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
    public class AssetAssetLiquidationRepository : EFRepository<AssetLiquidation>, IAssetAssetLiquidationRepository
    {
        public AssetAssetLiquidationRepository(Context context) : base(context) { }

        public async Task<AssetLiquidationModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(AssetAssetLiquidationExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<AssetLiquidationGridModel>> GridAsync(AssetLiquidationGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Code.ToLower().Contains(paramters.TextSearch)
                                    || m.Vendor.Name.ToLower().Contains(paramters.TextSearch));
            }

            var grid = await query.Select(AssetAssetLiquidationExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<AssetLiquidationGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(AssetLiquidation model, bool isCreate)
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
                    model.Code,
                    model.VendorId,
                    model.LiquidationDate,
                    model.TotalCost,
                    model.TotalDivices,
                    model.Notes,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetLiquidation model)
        {
            await UpdatePartialAsync(new
            {
                model.Id,
                model.Deleted,
                model.UpdateBy,
                model.UpdateDate
            });

            return true;
        }
    }
}
