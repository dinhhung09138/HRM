using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public interface IWardFactory
    {
        Ward Create(WardModel model);

        Ward Update(WardModel model);
    }
}
