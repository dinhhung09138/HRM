using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class UpdateEmployeeInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CurrentDepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CurrentPositionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeIdentification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IdentificationType",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "AcademicLevelId",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "BasicSalary",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "WorkingPhone",
                schema: "dbo",
                table: "Employee",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "WorkingEmail",
                schema: "dbo",
                table: "Employee",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "CurrentPositionId",
                schema: "dbo",
                table: "Employee",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "CurrentDepartmentId",
                schema: "dbo",
                table: "Employee",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CurrentPositionId",
                schema: "dbo",
                table: "Employee",
                newName: "IX_Employee_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CurrentDepartmentId",
                schema: "dbo",
                table: "Employee",
                newName: "IX_Employee_ManagerId");

            migrationBuilder.AddColumn<string>(
                name: "DriverLicenseCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DriverLicenseExpireDate",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DriverLicenseStartDate",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IdExpireDate",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdStartDate",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PassportCode",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportExpireDate",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportStartDate",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmergencyEmail",
                schema: "dbo",
                table: "EmployeeContact",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyName",
                schema: "dbo",
                table: "EmployeeContact",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhone",
                schema: "dbo",
                table: "EmployeeContact",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "JobPositionId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneExt",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResignDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ManagerId",
                schema: "dbo",
                table: "Employee",
                column: "ManagerId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_PositionId",
                schema: "dbo",
                table: "Employee",
                column: "PositionId",
                principalSchema: "dbo",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ManagerId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_PositionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DriverLicenseCode",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "DriverLicenseExpireDate",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "DriverLicenseStartDate",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "IdCode",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "IdExpireDate",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "IdStartDate",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "PassportCode",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "PassportExpireDate",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "PassportStartDate",
                schema: "dbo",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "EmergencyEmail",
                schema: "dbo",
                table: "EmployeeContact");

            migrationBuilder.DropColumn(
                name: "EmergencyName",
                schema: "dbo",
                table: "EmployeeContact");

            migrationBuilder.DropColumn(
                name: "EmergencyPhone",
                schema: "dbo",
                table: "EmployeeContact");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Fax",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobPositionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PhoneExt",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ResignDate",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                schema: "dbo",
                table: "Employee",
                newName: "CurrentPositionId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                schema: "dbo",
                table: "Employee",
                newName: "WorkingPhone");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                schema: "dbo",
                table: "Employee",
                newName: "CurrentDepartmentId");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "dbo",
                table: "Employee",
                newName: "WorkingEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PositionId",
                schema: "dbo",
                table: "Employee",
                newName: "IX_Employee_CurrentPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ManagerId",
                schema: "dbo",
                table: "Employee",
                newName: "IX_Employee_CurrentDepartmentId");

            migrationBuilder.AddColumn<long>(
                name: "AcademicLevelId",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "EmployeeInfo",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BasicSalary",
                schema: "dbo",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdentification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentificationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PlaceId = table.Column<long>(type: "bigint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIdentification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeIdentification_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeIdentification_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalSchema: "dbo",
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeIdentification_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "dbo",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdentification_EmployeeId",
                schema: "dbo",
                table: "EmployeeIdentification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdentification_IdentificationTypeId",
                schema: "dbo",
                table: "EmployeeIdentification",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdentification_PlaceId",
                schema: "dbo",
                table: "EmployeeIdentification",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CurrentDepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "CurrentDepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CurrentPositionId",
                schema: "dbo",
                table: "Employee",
                column: "CurrentPositionId",
                principalSchema: "dbo",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
