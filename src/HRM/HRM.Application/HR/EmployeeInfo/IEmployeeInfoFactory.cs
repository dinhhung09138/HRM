using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IEmployeeInfoFactory
    {
        EmployeeInfo Create(EmployeeInfoModel model);

        EmployeeInfo Update(EmployeeInfoModel model);
    }
}
