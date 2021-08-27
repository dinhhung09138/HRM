using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class SchoolFactory: ISchoolFactory
    {
        public School Create(SchoolModel model)
        {
            var item = new School(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, null, null);
            return item;
        }

        public School Update(SchoolModel model)
        {
            var item = new School(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
