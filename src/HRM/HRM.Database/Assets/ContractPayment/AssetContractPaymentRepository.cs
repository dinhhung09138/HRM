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
    public class AssetContractPaymentRepository : EFRepository<AssetContractPayment>, IAssetContractPaymentRepository
    {
        public AssetContractPaymentRepository(Context context) : base(context) { }

        public async Task<AssetContractPaymentModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(AssetContractPaymentExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<AssetContractPaymentGridModel>> GridAsync(AssetContractPaymentGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.AssetContract.Code.ToLower().Contains(paramters.TextSearch));
            }

            var grid = await query.Select(AssetContractPaymentExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<AssetContractPaymentGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(AssetContractPayment model, bool isCreate)
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
                    model.AssetContractId,
                    model.Payment,
                    model.Notes,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetContractPayment model)
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
