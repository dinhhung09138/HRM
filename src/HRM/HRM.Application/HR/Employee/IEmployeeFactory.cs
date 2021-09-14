using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IEmployeeFactory
    {
        Employee Create(EmployeeModel model);

        Employee Update(EmployeeModel model);
    }
}
