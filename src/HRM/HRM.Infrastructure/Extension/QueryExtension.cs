using HRM.Constant.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Extension
{
    public static class QueryExtension
    {
        public static List<T> ColumnSort<T>(this List<T> Source, Expression<Func<T, dynamic>> pression, TableSort sort)
        {
            switch (sort)
            {
                case TableSort.Asc:
                    return Source.AsQueryable().OrderBy(pression).ToList();
                case TableSort.Desc:
                    return Source.AsQueryable().OrderByDescending(pression).ToList();
            }
            return Source.ToList();
        }
    }
}
