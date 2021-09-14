using System;
using HRM.Model.HR;
using DotNetCore.Results;
using System.Threading.Tasks;

namespace HRM.Application.HR
{
    public interface IEmployeeInfoService
    {
        Task<IResult<EmployeeInfoModel>> FindByEmployeeIdAsync(long employeeId);

        Task<IResult<EmployeeInfoModel>> SaveAsync(EmployeeInfoModel model, bool isCreate);
    }
}
