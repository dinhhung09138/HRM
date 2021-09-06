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
    public class AssetContractRepository : EFRepository<AssetContract>, IAssetContractRepository
    {
        public AssetContractRepository(Context context) : base(context) { }

        public async Task<AssetContractModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(AssetContractExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<AssetContractGridModel>> GridAsync(AssetContractGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Code.ToLower().Contains(paramters.TextSearch));
            }

            if (!string.IsNullOrEmpty(paramters.VendorId))
            {
                query = query.Where(m => m.VendorId == long.Parse(paramters.VendorId));
            }

            var grid = await query.Select(AssetContractExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<AssetContractGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(AssetContract model, bool isCreate)
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
                    model.SignDate,
                    model.LiquidationDate,
                    model.TotalCost,
                    model.Notes,
                    model.IsActive,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetContract model)
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
