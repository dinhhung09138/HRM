using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class ModelOfStudyFactory : IModelOfStudyFactory
    {
        public ModelOfStudy Create(ModelOfStudyModel model)
        {
            var item = new ModelOfStudy(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public ModelOfStudy Update(ModelOfStudyModel model)
        {
            var item = new ModelOfStudy(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                model.UpdateBy,
                DateTime.Now);
            return item;
        }
    }
}
