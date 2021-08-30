using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class AssetModuleInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetHandoverInvoice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    HandoverBy = table.Column<long>(type: "bigint", nullable: false),
                    HandoverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveBy = table.Column<long>(type: "bigint", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetHandoverInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetHandoverInvoice_HandoverBy",
                        column: x => x.HandoverBy,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetHandoverInvoice_ReceiveBy",
                        column: x => x.ReceiveBy,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssetTypeId = table.Column<long>(type: "bigint", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MantenanceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LiquidationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AssetStatus = table.Column<int>(type: "int", nullable: false),
                    IsAllowBorrow = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalSchema: "dbo",
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "dbo",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetContract",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LiquidationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResidualValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_AssetContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetContract_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "dbo",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetLiquidation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    LiquidationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDivices = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLiquidation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLiquidation_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "dbo",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetFixing",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    FixingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetFixing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetFixing_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetFixing_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "dbo",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetHandoverInvoiceDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandoverInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetHandoverInvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetHandoverInvoiceDetail_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetHandoverInvoiceDetail_HandoverInvoiceId",
                        column: x => x.HandoverInvoiceId,
                        principalSchema: "dbo",
                        principalTable: "AssetHandoverInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetContractDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetContractId = table.Column<long>(type: "bigint", nullable: false),
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Vat = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetContractDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetContractDetail_AssetContractId",
                        column: x => x.AssetContractId,
                        principalSchema: "dbo",
                        principalTable: "AssetContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetContractDetail_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetContractPayment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetContractId = table.Column<long>(type: "bigint", nullable: false),
                    Payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetContractPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetContractPayment_AssetContractId",
                        column: x => x.AssetContractId,
                        principalSchema: "dbo",
                        principalTable: "AssetContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetLiquidationDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetLiquidationId = table.Column<long>(type: "bigint", nullable: false),
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLiquidationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLiquidationDetail_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "dbo",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetLiquidationDetail_AssetLiquidationId",
                        column: x => x.AssetLiquidationId,
                        principalSchema: "dbo",
                        principalTable: "AssetLiquidation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                schema: "dbo",
                table: "Asset",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_VendorId",
                schema: "dbo",
                table: "Asset",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetContract_VendorId",
                schema: "dbo",
                table: "AssetContract",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetContractDetail_AssetContractId",
                schema: "dbo",
                table: "AssetContractDetail",
                column: "AssetContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetContractDetail_AssetId",
                schema: "dbo",
                table: "AssetContractDetail",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetContractPayment_AssetContractId",
                schema: "dbo",
                table: "AssetContractPayment",
                column: "AssetContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetFixing_AssetId",
                schema: "dbo",
                table: "AssetFixing",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetFixing_VendorId",
                schema: "dbo",
                table: "AssetFixing",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetHandoverInvoice_HandoverBy",
                schema: "dbo",
                table: "AssetHandoverInvoice",
                column: "HandoverBy");

            migrationBuilder.CreateIndex(
                name: "IX_AssetHandoverInvoice_ReceiveBy",
                schema: "dbo",
                table: "AssetHandoverInvoice",
                column: "ReceiveBy");

            migrationBuilder.CreateIndex(
                name: "IX_AssetHandoverInvoiceDetail_AssetId",
                schema: "dbo",
                table: "AssetHandoverInvoiceDetail",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetHandoverInvoiceDetail_HandoverInvoiceId",
                schema: "dbo",
                table: "AssetHandoverInvoiceDetail",
                column: "HandoverInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLiquidation_VendorId",
                schema: "dbo",
                table: "AssetLiquidation",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLiquidationDetail_AssetId",
                schema: "dbo",
                table: "AssetLiquidationDetail",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLiquidationDetail_AssetLiquidationId",
                schema: "dbo",
                table: "AssetLiquidationDetail",
                column: "AssetLiquidationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetContractDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetContractPayment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetFixing",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetHandoverInvoiceDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetLiquidationDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetContract",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetHandoverInvoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Asset",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetLiquidation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "dbo");
        }
    }
}
