using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IContractTypeFactory
    {
        ContractType Create(ContractTypeModel model);

        ContractType Update(ContractTypeModel model);
    }
}
