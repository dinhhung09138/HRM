using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EthnicityFactory : IEthnicityFactory
    {
        public Ethnicity Create(EthnicityModel model)
        {
            var item = new Ethnicity(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public Ethnicity Update(EthnicityModel model)
        {
            var item = new Ethnicity(model.Id,
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
