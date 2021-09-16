using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class DepartmentFactory : IDepartmentFactory
    {
        public Department Create(DepartmentModel model)
        {
            var item = new Department(model.Id,
                model.Name,
                model.Description,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public Department Update(DepartmentModel model)
        {
            var item = new Department(model.Id,
                model.Name,
                model.Description,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                model.UpdateBy,
                DateTime.Now);
            return item;
        }
    }
}
