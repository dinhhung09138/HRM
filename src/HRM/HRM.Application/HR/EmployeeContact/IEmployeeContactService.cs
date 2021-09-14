using System;
using HRM.Model.HR;
using DotNetCore.Results;
using System.Threading.Tasks;

namespace HRM.Application.HR
{
    public interface IEmployeeContactService
    {
        Task<IResult<EmployeeContactModel>> FindByEmployeeIdAsync(long employeeId);

        Task<IResult<EmployeeContactModel>> SaveAsync(EmployeeContactModel model, bool isCreate);
    }
}
