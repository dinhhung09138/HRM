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
    public class AssetContractDetailRepository : EFRepository<AssetContractDetail>, IAssetContractDetailRepository
    {
        public AssetContractDetailRepository(Context context) : base(context) { }

        public async Task<AssetContractDetailModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id).Select(AssetContractDetailExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync(AssetContractDetail model, bool isCreate)
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
                    model.AssetTypeId,
                    model.Price,
                    model.Quantity,
                    model.Vat,
                    model.Total,
                    model.Notes
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetContractDetail model)
        {
            await DeleteAsync(model);

            return true;
        }
    }
}
