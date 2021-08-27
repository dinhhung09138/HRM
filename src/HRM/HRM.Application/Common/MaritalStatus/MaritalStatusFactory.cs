using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class MaritalStatusFactory: IMaritalStatusFactory
    {
        public MaritalStatus Create(MaritalStatusModel model)
        {
            var item = new MaritalStatus(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, null, null);
            return item;
        }

        public MaritalStatus Update(MaritalStatusModel model)
        {
            var item = new MaritalStatus(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
