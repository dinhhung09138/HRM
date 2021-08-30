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
    public class AssetFixingRepository : EFRepository<AssetFixing>, IAssetFixingRepository
    {
        public AssetFixingRepository(Context context) : base(context) { }

        public async Task<AssetFixingModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(AssetFixingExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<AssetFixingGridModel>> GridAsync(AssetFixingGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Asset.Name.ToLower().Contains(paramters.TextSearch)
                                    || m.Vendor.Name.ToLower().Contains(paramters.TextSearch));
            }

            var grid = await query.Select(AssetFixingExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<AssetFixingGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(AssetFixing model, bool isCreate)
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
                    model.AssetId,
                    model.VendorId,
                    model.Cost,
                    model.Notes,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetFixing model)
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
