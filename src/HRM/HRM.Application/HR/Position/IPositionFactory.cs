using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IPositionFactory
    {
        Position Create(PositionModel model);

        Position Update(PositionModel model);
    }
}
