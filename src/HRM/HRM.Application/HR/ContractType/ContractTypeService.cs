using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class ContractTypeService : IContractTypeService
    {
        private readonly IContractTypeRepository _contractTypeRepository;

        public ContractTypeService(
            IContractTypeRepository contractTypeRepository)
        {
            _contractTypeRepository = contractTypeRepository;
        }
    }
}
