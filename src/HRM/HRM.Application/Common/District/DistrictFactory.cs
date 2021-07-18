using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class DistrictFactory : IDistrictFactory
    {
        public District Create(DistrictModel model)
        {
            var item = new District(model.Id, model.Name, model.ProvinceId, 
                model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, 
                null, null);
            return item;
        }

        public District Update(DistrictModel model)
        {
            var item = new District(model.Id,
                model.Name, model.ProvinceId, model.Precedence,
                model.IsActive, model.CreateBy, DateTime.Now, 
                model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
