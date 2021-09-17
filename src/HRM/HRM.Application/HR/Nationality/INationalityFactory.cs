using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface INationalityFactory
    {
        Nationality Create(NationalityModel model);

        Nationality Update(NationalityModel model);
    }
}
