using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class CustomerExpression
    {
        public static Expression<Func<Customer, CustomerModel>> FindByIdAsync => m => new CustomerModel()
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

        public static Expression<Func<Customer, CustomerGridModel>> GridAsync => m => new CustomerGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Phone = m.Phone,
            Email = m.Email,
            Address = m.Address,
            IsActive = m.IsActive
        };
    }
}
