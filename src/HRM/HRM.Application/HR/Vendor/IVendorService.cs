using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.HR
{
    public interface IVendorService
    {
        Task<IResult<VendorModel>> FindByIdAsync(long id);

        Task<IResult<Grid<VendorGridModel>>> GridAsync(VendorGridParameterModel paramters);

        Task<IResult> SaveAsync(VendorModel model, bool isCreate);

        Task<IResult> DeleteAsync(VendorModel model);
    }
}
