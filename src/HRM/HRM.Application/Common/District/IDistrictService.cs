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
    public interface IDistrictService
    {
        Task<IResult> FindByIdAsync(long id);

        Task<IResult> GridAsync(DistrictGridParameterModel paramters);

        Task<IResult> SaveAsync(DistrictModel model, bool isCreate);

        Task<IResult> DeleteAsync(DistrictModel model);
    }
}
