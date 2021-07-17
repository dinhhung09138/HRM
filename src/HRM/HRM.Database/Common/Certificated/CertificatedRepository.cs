using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;
using System.Linq;

namespace HRM.Database.Common
{
    public class CertificatedRepository : EFRepository<Certificated>, ICertificatedRepository
    {
        public CertificatedRepository(Context context) : base(context) { }

        public async Task<CertificatedModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id).Select(CertificatedExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public Task<Grid<CertificatedGridModel>> GridAsync(CertificatedGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
            }

            //var e = new GridParameters()
            //{
            //    Order = paramters.Order,
            //    Page = paramters.Page
            //};

            var grid = query.Select(CertificatedExpression.GridAsync).GridAsync(paramters);

            return grid;
        }

        public async Task<bool> SaveAsync(Certificated model, bool isCreate)
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
                    model.IsActive,
                    model.Precedence,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }


        public async Task<bool> DeleteAsync(Certificated model)
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
