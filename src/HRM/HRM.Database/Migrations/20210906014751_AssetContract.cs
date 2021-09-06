using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class AssetContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetContractDetail_AssetId",
                schema: "dbo",
                table: "AssetContractDetail");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                schema: "dbo",
                table: "AssetContractDetail",
                newName: "AssetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetContractDetail_AssetId",
                schema: "dbo",
                table: "AssetContractDetail",
                newName: "IX_AssetContractDetail_AssetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetContractDetail_AssetTypeId",
                schema: "dbo",
                table: "AssetContractDetail",
                column: "AssetTypeId",
                principalSchema: "dbo",
                principalTable: "AssetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetContractDetail_AssetTypeId",
                schema: "dbo",
                table: "AssetContractDetail");

            migrationBuilder.RenameColumn(
                name: "AssetTypeId",
                schema: "dbo",
                table: "AssetContractDetail",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetContractDetail_AssetTypeId",
                schema: "dbo",
                table: "AssetContractDetail",
                newName: "IX_AssetContractDetail_AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetContractDetail_AssetId",
                schema: "dbo",
                table: "AssetContractDetail",
                column: "AssetId",
                principalSchema: "dbo",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
