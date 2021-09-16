using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class JobPositionFactory : IJobPositionFactory
    {
        public JobPosition Create(JobPositionModel model)
        {
            var item = new JobPosition(model.Id,
                model.Name,
                model.Description,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public JobPosition Update(JobPositionModel model)
        {
            var item = new JobPosition(model.Id,
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
