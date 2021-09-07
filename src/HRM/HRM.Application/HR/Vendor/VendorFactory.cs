using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class VendorFactory : IVendorFactory
    {
        public Vendor Create(VendorModel model)
        {
            var item = new Vendor(model.Id, 
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

        public Vendor Update(VendorModel model)
        {
            var item = new Vendor(model.Id,
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
