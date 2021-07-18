using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;
using DotNetCore.Results;
using System.Threading.Tasks;

namespace HRM.Application.Common
{
    public interface IProvinceService
    {
        Task<IResult> FindByIdAsync(long id);

        Task<IResult> GridAsync(ProvinceGridParameterModel paramters);

        Task<IResult> SaveAsync(ProvinceModel model, bool isCreate);

        Task<IResult> DeleteAsync(ProvinceModel model);
    }
}
