using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class VendorExpression
    {
        public static Expression<Func<Vendor, VendorModel>> FindByIdAsync => m => new VendorModel()
        {
            Id = m.Id,
            Name = m.Name,
            Phone = m.Phone,
            Email = m.Email,
            Address = m.Address,
            Notes = m.Notes,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Vendor, VendorGridModel>> GridAsync => m => new VendorGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Phone = m.Phone,
            Email = m.Email,
            Address = m.Address,
            Notes = m.Notes,
            IsActive = m.IsActive
        };
    }
}
