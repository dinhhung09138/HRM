using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class EthnicitySeedData
    {
        public static void SeedEthnicitys(this ModelBuilder builder)
        {
            builder.Entity<Ethnicity>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    Name = "Kinh",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 2L,
                    Name = "Chăm",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 3L,
                    Name = "Bana",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
            });
        }
    }
}
