using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class InitDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Ethnicity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ContractType",
                columns: new[] { "Id", "AllowInsurance", "AllowLeaveDate", "Code", "CreateBy", "CreateDate", "Deleted", "Description", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, true, false, "Probation", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", true, "HD thử việc", 1, null, null },
                    { 2L, true, true, "1Year", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", true, "HĐ 1 năm", 1, null, null },
                    { 3L, true, true, "2Year", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", true, "HD 2 năm", 1, null, null },
                    { 4L, true, false, "3Year", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", true, "HĐ 3 năm", 1, null, null },
                    { 5L, true, true, "Forever", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", true, "HĐ vô thời hạn", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ethnicity",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Kinh", 1, null, null },
                    { 2L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Chăm", 1, null, null },
                    { 3L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Bana", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "LeaveType",
                columns: new[] { "Id", "Code", "CreateBy", "CreateDate", "Deleted", "Description", "IsActive", "IsDeductible", "Name", "NumOfDay", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 3L, "Pregnant", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Thời gian nghỉ thai sản có tính lương (Bảo hiểm xã hội chi trả)", true, false, "Nghỉ thai sản", 0, 3, null, null },
                    { 1L, "NoPaid", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Thời gian nghỉ sẽ được trừ vào lương", true, false, "Nghỉ không lương", 0, 1, null, null },
                    { 2L, "Paid", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Thời gian nghỉ sẽ không bị trừ lương mà được tính vào ngày phép", true, true, "Nghỉ phép", 12, 2, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ModelOfStudy",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Chính quy", 1, null, null },
                    { 2L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Vừa học vừa làm", 1, null, null },
                    { 3L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "E-Learning", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Nationality",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 7L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Anh", 1, null, null },
                    { 9L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Canada", 1, null, null },
                    { 8L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Đức", 1, null, null },
                    { 5L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Campuchia", 1, null, null },
                    { 6L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Ấn độ", 1, null, null },
                    { 3L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Hàn Quốc", 1, null, null },
                    { 2L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Nhật Bản", 1, null, null },
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Việt Nam", 1, null, null },
                    { 4L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Trung Quốc", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ranking",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Xuất sắc", 1, null, null },
                    { 2L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Giỏi", 1, null, null },
                    { 3L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Khá", 1, null, null },
                    { 4L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Trung bình", 1, null, null },
                    { 5L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Yếu", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RelationshipType",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Cha/Mẹ", 1, null, null },
                    { 2L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Vợ/Chồng", 1, null, null },
                    { 3L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Cô/Chú", 1, null, null },
                    { 4L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Con", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Religion",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Deleted", "IsActive", "Name", "Precedence", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 5L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Hồi giáo", 1, null, null },
                    { 4L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Cao đài", 1, null, null },
                    { 6L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Hòa hảo", 1, null, null },
                    { 2L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Phật giáo", 1, null, null },
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Công giáo", 1, null, null },
                    { 3L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Tin lành", 1, null, null },
                    { 7L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Ấn độ giáo", 1, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ContractType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ContractType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ContractType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ContractType",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ContractType",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ethnicity",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ethnicity",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ethnicity",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ModelOfStudy",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ModelOfStudy",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ModelOfStudy",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ranking",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ranking",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ranking",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ranking",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Ranking",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RelationshipType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RelationshipType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RelationshipType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RelationshipType",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Religion",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Ethnicity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
