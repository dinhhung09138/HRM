using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IEmployeeWorkingStatusFactory
    {
        EmployeeWorkingStatus Create(EmployeeWorkingStatusModel model);

        EmployeeWorkingStatus Update(EmployeeWorkingStatusModel model);
    }
}
