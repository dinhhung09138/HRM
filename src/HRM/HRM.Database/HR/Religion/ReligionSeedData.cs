using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class ReligionSeedData
    {
        public static void SeedReligions(this ModelBuilder builder)
        {
            builder.Entity<Religion>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    Name = "Công giáo",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 2L,
                    Name = "Phật giáo",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 3L,
                    Name = "Tin lành",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 4L,
                    Name = "Cao đài",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 5L,
                    Name = "Hồi giáo",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 6L,
                    Name = "Hòa hảo",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 7L,
                    Name = "Ấn độ giáo",
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
