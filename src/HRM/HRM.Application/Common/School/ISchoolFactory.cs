using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public interface ISchoolFactory
    {
        School Create(SchoolModel model);

        School Update(SchoolModel model);
    }
}
