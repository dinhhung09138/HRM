using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public interface ICertificatedFactory
    {
        Certificated Create(CertificatedModel model);

        Certificated Update(CertificatedModel model);
    }
}
