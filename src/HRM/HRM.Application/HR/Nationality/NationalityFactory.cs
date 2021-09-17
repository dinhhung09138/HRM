using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class NationalityFactory : INationalityFactory
    {
        public Nationality Create(NationalityModel model)
        {
            var item = new Nationality(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public Nationality Update(NationalityModel model)
        {
            var item = new Nationality(model.Id,
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
