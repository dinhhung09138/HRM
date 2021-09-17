using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class NationalitySeedData
    {
        public static void SeedNationalitys(this ModelBuilder builder)
        {
            builder.Entity<Nationality>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    Name = "Việt Nam",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 2L,
                    Name = "Nhật Bản",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 3L,
                    Name = "Hàn Quốc",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 4L,
                    Name = "Trung Quốc",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 5L,
                    Name = "Campuchia",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 6L,
                    Name = "Ấn độ",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 7L,
                    Name = "Anh",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 8L,
                    Name = "Đức",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 9L,
                    Name = "Canada",
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
