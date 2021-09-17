using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRM.Database.HR
{
    public static class LeaveTypeSeedData
    {
        public static void SeedLeaveTypes(this ModelBuilder builder)
        {
            builder.Entity<LeaveType>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    Code = "NoPaid",
                    Name = "Nghỉ không lương",
                    NumOfDay = 0,
                    IsDeductible = false,
                    Description = "Thời gian nghỉ sẽ được trừ vào lương",
                    Precedence = 1,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 2L,
                    Code = "Paid",
                    Name = "Nghỉ phép",
                    NumOfDay = 12,
                    IsDeductible = true,
                    Description = "Thời gian nghỉ sẽ không bị trừ lương mà được tính vào ngày phép",
                    Precedence = 2,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
                user.HasData(new
                {
                    Id = 3L,
                    Code = "Pregnant",
                    Name = "Nghỉ thai sản",
                    NumOfDay = 0,
                    IsDeductible = false,
                    Description = "Thời gian nghỉ thai sản có tính lương (Bảo hiểm xã hội chi trả)",
                    Precedence = 3,
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
            });
        }
    }
}
