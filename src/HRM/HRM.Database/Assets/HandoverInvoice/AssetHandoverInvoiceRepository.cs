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
    public class AssetHandoverInvoiceRepository : EFRepository<AssetHandoverInvoice>, IAssetHandoverInvoiceRepository
    {
        public AssetHandoverInvoiceRepository(Context context) : base(context) { }

        public async Task<AssetHandoverInvoiceModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(AssetHandoverInvoiceExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<AssetHandoverInvoiceGridModel>> GridAsync(AssetHandoverInvoiceGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Code.ToLower().Contains(paramters.TextSearch)
                                    || m.Handover.EmployeeInfo.FullName.ToLower().Contains(paramters.TextSearch)
                                    || m.Receiver.EmployeeInfo.FullName.ToLower().Contains(paramters.TextSearch));
            }

            var grid = await query.Select(AssetHandoverInvoiceExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<AssetHandoverInvoiceGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(AssetHandoverInvoice model, bool isCreate)
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
                    model.HandoverBy,
                    model.HandoverDate,
                    model.ReceiveBy,
                    model.ReceiveDate,
                    model.Notes,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(AssetHandoverInvoice model)
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
