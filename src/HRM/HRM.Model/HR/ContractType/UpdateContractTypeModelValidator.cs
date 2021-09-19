using System;

namespace HRM.Model.HR
{
    public class UpdateContractTypeModelValidator : ContractTypeValidator
    {
        public UpdateContractTypeModelValidator()
        {
            Id();
            Code();
            Name();
            Description();
        }
    }
}
