using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class CustomerContactExpression
    {
        public static Expression<Func<CustomerContact, CustomerContactModel>> FindByIdAsync => m => new CustomerContactModel()
        {
            Id = m.Id,
            CustomerId = m.CustomerId,
            Name = m.Name,
            Phone = m.Phone,
            Email = m.Email,
            Position = m.Position,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<CustomerContact, CustomerContactGridModel>> GridAsync => m => new CustomerContactGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Phone = m.Position,
            Email = m.Email,
            Position = m.Position
        };
    }
}
