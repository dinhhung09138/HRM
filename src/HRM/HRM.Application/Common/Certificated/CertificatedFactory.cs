using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class CertificatedFactory : ICertificatedFactory
    {
        public Certificated Create(CertificatedModel model)
        {
            var item = new Certificated(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, model.UpdateBy, DateTime.Now);
            return item;
        }

        public Certificated Update(CertificatedModel model)
        {
            var item = new Certificated(model.Id, model.Name, model.Precedence, model.IsActive, model.CreateBy, DateTime.Now, model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
