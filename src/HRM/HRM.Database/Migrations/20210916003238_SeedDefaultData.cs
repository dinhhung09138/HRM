using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class SeedDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Branch",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "Description", "IsActive", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", true, "Trụ sở chính", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employee",
                columns: new[] { "Id", "BadgeCardNumber", "BranchId", "CreateBy", "CreateDate", "DateApplyBadge", "DateApplyFingerSign", "Deleted", "DepartmentId", "Email", "EmployeeCode", "EmployeeWorkingStatusId", "Fax", "FingerSignNumber", "FullName", "IsActive", "JobPositionId", "ManagerId", "Phone", "PhoneExt", "PositionId", "ProbationDate", "ResignDate", "StartWorkingDate", "UpdateBy", "UpdateDate" },
                values: new object[] { 1L, null, 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "System", null, null, null, "Admistrator", true, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemUser",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "EmployeeId", "IsActive", "Password", "Salt", "UpdateBy", "UpdateDate", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1L, true, "aFMD6v1O8DqaqXYAOsmDxOhdqZS0ZkufVGP0aXj+gZwe02YX/JshTurtmDZfkGY24hi+9EUgcqllimm7piyHry7RKVMJnGmbyYZua6PZxiqTfDMDLU0+n/Puj6+ud6LTa0FTSSIUGzaqUnxwlR9JXGw6qjJasQzqPR8rX3JCkHnZSlkMvL4YNPOY5NaR/7kwoEIl8Nz8mDPt2GMpIfmvZGOle+z2wbdNxRHuV1NO7Ya8XJstsvguHlZypQ9sK62LutKmsrQSrnmiojxvnWLJ8zCqDvsYTEbJZdfrzLojf+RhoBBN2wMQrgy8YsZB6ienykxj3jdmFzNFN22MMLmtN/brlg2oPx5loQjPZnkw10+azZUxMyjxulIJdOtBIWJnAOINOWGU31tXkiio1mJOey54rPE19YbG+QvqvHcNcVKkakqr4yKRT5/DS5+pM6MKQxeeQbdMPpjfpreCV/WzxKwhqklMhQCWmuekD6pYXCi6oj0EjjVxr51kR4BxKm0A3kwnpbdKVOm32GsSxH3t0lQT5xgUf0jsq2Ure6vp7xbLmoGpdT6++ZDe9sKJjNE38u4Nf0uZuYbpIA4SbmvaJ9FtmGxH/SFr6EG0KhmyHSx58FMMcrLcbCoL2N60r6ZG9F+xkusRuuGuq7NW5Zass/jLGz6uCKaW8ZMvSlkGOrM=", "FFF77F62-8E21-4A8E-B338-6445DAA5D75B", null, null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
