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
    public class AssetHandoverInvoiceDetailRepository : EFRepository<AssetHandoverInvoiceDetail>, IAssetHandoverInvoiceDetailRepository
    {
        public AssetHandoverInvoiceDetailRepository(Context context) : base(context) { }

        public async Task<bool> SaveAsync(AssetHandoverInvoiceDetail model, bool isCreate)
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
                    model.HandoverInvoiceId,
                    model.AssetId,
                    model.Notes,
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetHandoverInvoiceDetail model)
        {
            await DeleteAsync(model);

            return true;
        }
    }
}
