using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class EmployeeSeedData
    {
        public static void SeedEmployees(this ModelBuilder builder)
        {
            builder.Entity<Employee>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    EmployeeCode = "System",
                    FullName = "Admistrator",
                    BranchId = 1L,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
            });
        }
    }
}
