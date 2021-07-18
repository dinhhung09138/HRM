using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class ProvinceFactory: IProvinceFactory
    {
        public Province Create(ProvinceModel model)
        {
            var item = new Province(model.Id, model.Name, 
                model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, 
                null, null);
            return item;
        }

        public Province Update(ProvinceModel model)
        {
            var item = new Province(model.Id, model.Name, 
                model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, 
                model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
