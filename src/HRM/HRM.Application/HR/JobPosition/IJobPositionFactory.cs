using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IJobPositionFactory
    {
        JobPosition Create(JobPositionModel model);

        JobPosition Update(JobPositionModel model);
    }
}
