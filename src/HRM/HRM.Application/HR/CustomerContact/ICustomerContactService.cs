using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.HR
{
    public interface ICustomerContactService
    {
        Task<IResult<CustomerContactModel>> FindByIdAsync(long id);

        Task<IResult<Grid<CustomerContactGridModel>>> GridAsync(CustomerContactGridParameterModel paramters);

        Task<IResult> SaveAsync(CustomerContactModel model, bool isCreate);

        Task<IResult> DeleteAsync(CustomerContactModel model);
    }
}
