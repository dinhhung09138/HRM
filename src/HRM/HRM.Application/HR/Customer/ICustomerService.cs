using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.HR
{
    public interface ICustomerService
    {
        Task<IResult<CustomerModel>> FindByIdAsync(long id);

        Task<IResult<Grid<CustomerGridModel>>> GridAsync(CustomerGridParameterModel paramters);

        Task<IResult> SaveAsync(CustomerModel model, bool isCreate);

        Task<IResult> DeleteAsync(CustomerModel model);
    }
}
