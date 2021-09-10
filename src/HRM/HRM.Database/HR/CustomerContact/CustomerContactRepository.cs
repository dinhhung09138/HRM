using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;

namespace HRM.Database.HR
{
    public class CustomerContactRepository : EFRepository<CustomerContact>, ICustomerContactRepository
    {
        public CustomerContactRepository(Context context) : base(context) { }

        public async Task<CustomerContactModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(CustomerContactExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<CustomerContactGridModel>> GridAsync(CustomerContactGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.CustomerId == paramters.CustomerId && m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch)
                                        || m.Phone.ToLower().Contains(paramters.TextSearch)
                                        || m.Email.ToLower().Contains(paramters.TextSearch)
                                        || m.Position.ToLower().Contains(paramters.TextSearch));
            }

            query = query.OrderBy(m => m.Name);

            var grid = await query.Select(CustomerContactExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<CustomerContactGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(CustomerContact model, bool isCreate)
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
                    model.Name,
                    model.Phone,
                    model.Email,
                    model.Position,
                    model.CustomerId,
                    model.IsActive,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(CustomerContact model)
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

        public async Task<bool> IsCurrentVersion(long id, byte[] rowVersion)
        {
            return await Queryable.AnyAsync(m => !m.Deleted && m.Id == id && m.RowVersion == rowVersion);
        }

    }
}
