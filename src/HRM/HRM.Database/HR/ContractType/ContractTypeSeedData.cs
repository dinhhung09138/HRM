using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class ContractTypeSeedData
    {
        public static void SeedContractTypes(this ModelBuilder builder)
        {
            builder.Entity<ContractType>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    Code = "Probation",
                    Name = "HD thử việc",
                    Description = "",
                    AllowInsurance = true,
                    AllowLeaveDate = false,
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 2L,
                    Code = "1Year",
                    Name = "HĐ 1 năm",
                    Description = "",
                    AllowInsurance = true,
                    AllowLeaveDate = true,
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 3L,
                    Code = "2Year",
                    Name = "HD 2 năm",
                    Description = "",
                    AllowInsurance = true,
                    AllowLeaveDate = true,
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 4L,
                    Code = "3Year",
                    Name = "HĐ 3 năm",
                    Description = "",
                    AllowInsurance = true,
                    AllowLeaveDate = false,
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 5L,
                    Code = "Forever",
                    Name = "HĐ vô thời hạn",
                    Description = "",
                    AllowInsurance = true,
                    AllowLeaveDate = true,
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
