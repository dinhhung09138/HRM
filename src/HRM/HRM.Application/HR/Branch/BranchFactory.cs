using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class BranchFactory : IBranchFactory
    {
        public Branch Create(BranchModel model)
        {
            var item = new Branch(model.Id,
                model.Name,
                model.Description,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public Branch Update(BranchModel model)
        {
            var item = new Branch(model.Id,
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
