using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public interface IMajorFactory
    {
        Major Create(MajorModel model);

        Major Update(MajorModel model);
    }
}
