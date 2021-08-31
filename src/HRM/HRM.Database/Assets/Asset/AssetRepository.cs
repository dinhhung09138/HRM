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
    public class AssetRepository : EFRepository<Asset>, IAssetRepository
    {
        public AssetRepository(Context context) : base(context) { }

        public async Task<AssetModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(AssetExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<AssetGridModel>> GridAsync(AssetGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch)
                                        || m.Code.ToLower().Contains(paramters.TextSearch)
                                        || m.AssetType.Name.ToLower().Contains(paramters.TextSearch));
            }

            if (!string.IsNullOrEmpty(paramters.AssetTypeId))
            {
                var listData = paramters.AssetTypeId.Split(',');

                List<long> typeIds = new List<long>();
                foreach (var item in listData)
                {
                    typeIds.Add(long.Parse(item));
                }

                query = query.Where(m => typeIds.Contains(m.AssetTypeId));
            }

            var grid = await query.Select(AssetExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<AssetGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(Asset model, bool isCreate)
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
                    model.Name,
                    model.SerialNumber,
                    model.AssetTypeId,
                    model.VendorId,
                    model.Cost,
                    model.BuyingDate,
                    model.WarrantyExpiryDate,
                    model.LiquidationDate,
                    model.Notes,
                    model.AssetStatus,
                    model.IsAllowBorrow,
                    model.IsActive,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Asset model)
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
