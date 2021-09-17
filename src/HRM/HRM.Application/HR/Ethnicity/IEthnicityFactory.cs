using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IEthnicityFactory
    {
        Ethnicity Create(EthnicityModel model);

        Ethnicity Update(EthnicityModel model);
    }
}
