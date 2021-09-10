using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class CustomerContactFactory : ICustomerContactFactory
    {
        public CustomerContact Create(CustomerContactModel model)
        {
            var item = new CustomerContact(model.Id, 
                model.CustomerId,
                model.Name,
                model.Phone,
                model.Email,
                model.Position,
                model.IsActive, 
                model.CreateBy, 
                DateTime.Now, 
                null, null);
            return item;
        }

        public CustomerContact Update(CustomerContactModel model)
        {
            var item = new CustomerContact(model.Id,
                model.CustomerId,
                model.Name,
                model.Phone,
                model.Email,
                model.Position,
                model.IsActive,
                model.CreateBy, 
                DateTime.Now, 
                model.UpdateBy, 
                DateTime.Now);
            return item;
        }
    }
}
