using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class WardFactory: IWardFactory
    {
        public Ward Create(WardModel model)
        {
            var item = new Ward(model.Id, model.Name, model.DistrictId, 
                model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, 
                null, null);
            return item;
        }

        public Ward Update(WardModel model)
        {
            var item = new Ward(model.Id, model.Name, model.DistrictId, 
                model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, 
                model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
