using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IVendorService
    {
        Task<IResult<VendorModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<VendorGridModel>>> GridAsync(VendorGridParameterModel paramters);

        Task<IResult> SaveAsync(VendorModel model, bool isCreate);

        Task<IResult> DeleteAsync(VendorModel model);
    }
}
