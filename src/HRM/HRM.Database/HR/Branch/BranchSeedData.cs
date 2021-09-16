using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class BranchSeedData
    {
        public static void SeedBranchs(this ModelBuilder builder)
        {
            builder.Entity<Branch>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    Name = "Trụ sở chính",
                    Description = string.Empty,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
            });
        }
    }
}
