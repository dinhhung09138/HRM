using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public interface IDistrictFactory
    {
        District Create(DistrictModel model);

        District Update(DistrictModel model);
    }
}
