using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IModelOfStudyFactory
    {
        ModelOfStudy Create(ModelOfStudyModel model);

        ModelOfStudy Update(ModelOfStudyModel model);
    }
}
