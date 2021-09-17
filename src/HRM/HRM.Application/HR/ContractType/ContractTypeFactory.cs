using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class ContractTypeFactory : IContractTypeFactory
    {
        public ContractType Create(ContractTypeModel model)
        {
            var item = new ContractType(model.Id,
                model.Code,
                model.Name,
                model.Description,
                model.AllowInsurance,
                model.AllowLeaveDate,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public ContractType Update(ContractTypeModel model)
        {
            var item = new ContractType(model.Id,
                model.Code,
                model.Name,
                model.Description,
                model.AllowInsurance,
                model.AllowLeaveDate,
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
