using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer Create(CustomerModel model)
        {
            var item = new Customer(model.Id, 
                model.Name,
                model.Phone,
                model.Email,
                model.Address,
                model.TaxCode,
                model.Notes,
                model.IsActive, 
                model.CreateBy, 
                DateTime.Now, 
                null, null);
            return item;
        }

        public Customer Update(CustomerModel model)
        {
            var item = new Customer(model.Id,
                model.Name,
                model.Phone,
                model.Email,
                model.Address,
                model.TaxCode,
                model.Notes,
                model.IsActive,
                model.CreateBy, 
                DateTime.Now, 
                model.UpdateBy, 
                DateTime.Now);
            return item;
        }
    }
}
