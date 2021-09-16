using HRM.Domain.System;
using Microsoft.EntityFrameworkCore;
using System;


namespace HRM.Database.System
{
    public static class SystemUserSeedData
    {
        public static void SeedSystemUsers(this ModelBuilder builder)
        {
            builder.Entity<SystemUser>(user =>
            {
                user.HasData(new
                {
                    Id = 1L,
                    EmployeeId = 1L,
                    UserName = "admin",
                    Password = "aFMD6v1O8DqaqXYAOsmDxOhdqZS0ZkufVGP0aXj+gZwe02YX/JshTurtmDZfkGY24hi+9EUgcqllimm7piyHry7RKVMJnGmbyYZua6PZxiqTfDMDLU0+n/Puj6+ud6LTa0FTSSIUGzaqUnxwlR9JXGw6qjJasQzqPR8rX3JCkHnZSlkMvL4YNPOY5NaR/7kwoEIl8Nz8mDPt2GMpIfmvZGOle+z2wbdNxRHuV1NO7Ya8XJstsvguHlZypQ9sK62LutKmsrQSrnmiojxvnWLJ8zCqDvsYTEbJZdfrzLojf+RhoBBN2wMQrgy8YsZB6ienykxj3jdmFzNFN22MMLmtN/brlg2oPx5loQjPZnkw10+azZUxMyjxulIJdOtBIWJnAOINOWGU31tXkiio1mJOey54rPE19YbG+QvqvHcNcVKkakqr4yKRT5/DS5+pM6MKQxeeQbdMPpjfpreCV/WzxKwhqklMhQCWmuekD6pYXCi6oj0EjjVxr51kR4BxKm0A3kwnpbdKVOm32GsSxH3t0lQT5xgUf0jsq2Ure6vp7xbLmoGpdT6++ZDe9sKJjNE38u4Nf0uZuYbpIA4SbmvaJ9FtmGxH/SFr6EG0KhmyHSx58FMMcrLcbCoL2N60r6ZG9F+xkusRuuGuq7NW5Zass/jLGz6uCKaW8ZMvSlkGOrM=",
                    Salt = "FFF77F62-8E21-4A8E-B338-6445DAA5D75B",
                    IsActive = true,
                    CreateBy = 1L,
                    CreateDate = new DateTime(2021, 01, 01),
                    Deleted = false
                });
            });
        }
    }
}
