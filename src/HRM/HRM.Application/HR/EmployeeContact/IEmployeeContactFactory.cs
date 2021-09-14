using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IEmployeeContactFactory
    {
        EmployeeContact Create(EmployeeContactModel model);

        EmployeeContact Update(EmployeeContactModel model);

    }
}
