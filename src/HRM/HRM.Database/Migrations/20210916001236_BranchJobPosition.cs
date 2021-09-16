using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class BranchJobPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precedence",
                schema: "dbo",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "Precedence",
                schema: "dbo",
                table: "EmployeeWorkingStatus");

            migrationBuilder.DropColumn(
                name: "Precedence",
                schema: "dbo",
                table: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Position",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "EmployeeWorkingStatus",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PassportCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DriverLicenseCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Department",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BranchId",
                schema: "dbo",
                table: "Employee",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobPositionId",
                schema: "dbo",
                table: "Employee",
                column: "JobPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_BranchId",
                schema: "dbo",
                table: "Employee",
                column: "BranchId",
                principalSchema: "dbo",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobPositionId",
                schema: "dbo",
                table: "Employee",
                column: "JobPositionId",
                principalSchema: "dbo",
                principalTable: "JobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_BranchId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobPositionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobPosition",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BranchId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobPositionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Position",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Precedence",
                schema: "dbo",
                table: "Position",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "EmployeeWorkingStatus",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Precedence",
                schema: "dbo",
                table: "EmployeeWorkingStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PassportCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DriverLicenseCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Department",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Precedence",
                schema: "dbo",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
