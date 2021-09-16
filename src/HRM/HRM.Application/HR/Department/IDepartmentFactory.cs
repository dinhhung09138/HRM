using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IDepartmentFactory
    {
        Department Create(DepartmentModel model);

        Department Update(DepartmentModel model);
    }
}
