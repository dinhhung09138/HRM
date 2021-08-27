﻿using System;
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
    public sealed class MajorRepository : EFRepository<Major>, IMajorRepository
    {
        public MajorRepository(Context context) : base(context) { }

        public async Task<MajorModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(MajorExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<MajorGridModel>> GridAsync(MajorGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
            }

            var grid = await query.Select(MajorExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<MajorGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<bool> SaveAsync(Major model, bool isCreate)
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

        public async Task<bool> DeleteAsync(Major model)
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
