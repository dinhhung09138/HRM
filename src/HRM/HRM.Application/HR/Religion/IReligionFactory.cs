using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IReligionFactory
    {
        Religion Create(ReligionModel model);

        Religion Update(ReligionModel model);
    }
}
