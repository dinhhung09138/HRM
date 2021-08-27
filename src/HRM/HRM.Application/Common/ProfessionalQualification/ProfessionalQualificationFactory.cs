using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class ProfessionalQualificationFactory: IProfessionalQualificationFactory
    {
        public ProfessionalQualification Create(ProfessionalQualificationModel model)
        {
            var item = new ProfessionalQualification(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, null, null);
            return item;
        }

        public ProfessionalQualification Update(ProfessionalQualificationModel model)
        {
            var item = new ProfessionalQualification(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
