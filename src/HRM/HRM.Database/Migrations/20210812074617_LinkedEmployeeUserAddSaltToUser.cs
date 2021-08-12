using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class LinkedEmployeeUserAddSaltToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                schema: "dbo",
                table: "SystemUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                schema: "dbo",
                table: "SystemUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_EmployeeId",
                schema: "dbo",
                table: "SystemUser",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUser_EmployeeId",
                schema: "dbo",
                table: "SystemUser",
                column: "EmployeeId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUser_EmployeeId",
                schema: "dbo",
                table: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_SystemUser_EmployeeId",
                schema: "dbo",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "dbo",
                table: "SystemUser");
        }
    }
}
