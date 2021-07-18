using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Database.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificated",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Certificated", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commendation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Commendation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AllowInsurance = table.Column<bool>(type: "bit", nullable: false),
                    AllowLeaveDate = table.Column<bool>(type: "bit", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkingStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeWorkingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Ethnicity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MineType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    SystemFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FilePath32 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FilePath64 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FilePath128 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumOfDay = table.Column<int>(type: "int", nullable: false),
                    IsDeductible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LeaveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelOfStudy",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ModelOfStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalQualification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProfessionalQualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RelationshipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    ProbationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartWorkingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BadgeCardNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateApplyBadge = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FingerSignNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateApplyFingerSign = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkingPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeWorkingStatusId = table.Column<long>(type: "bigint", nullable: true),
                    CurrentPositionId = table.Column<long>(type: "bigint", nullable: true),
                    CurrentDepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_CurrentDepartmentId",
                        column: x => x.CurrentDepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_CurrentPositionId",
                        column: x => x.CurrentPositionId,
                        principalSchema: "dbo",
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeWorkingStatusId",
                        column: x => x.EmployeeWorkingStatusId,
                        principalSchema: "dbo",
                        principalTable: "EmployeeWorkingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBank",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountOwner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_EmployeeBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeBank_BankId",
                        column: x => x.BankId,
                        principalSchema: "dbo",
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeBank_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCertificate",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CertificatedId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCertificate_CertificatedId",
                        column: x => x.CertificatedId,
                        principalSchema: "dbo",
                        principalTable: "Certificated",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCertificate_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCertificate_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "dbo",
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCommendation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CommendationId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProposerId = table.Column<long>(type: "bigint", nullable: false),
                    ProposeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeCommendation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCommendation_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCommendation_CommendationId",
                        column: x => x.CommendationId,
                        principalSchema: "dbo",
                        principalTable: "Commendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCommendation_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCommendation_ProposerId",
                        column: x => x.ProposerId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContract",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeProcessId = table.Column<long>(type: "bigint", nullable: false),
                    ContractTypeId = table.Column<long>(type: "bigint", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContract_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalSchema: "dbo",
                        principalTable: "ContractType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContract_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContract_EmployeeProcessId",
                        column: x => x.EmployeeProcessId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDependency",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RelationshipTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeDependency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDependency_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDependency_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalSchema: "dbo",
                        principalTable: "RelationshipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDiscipline",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DisciplineId = table.Column<long>(type: "bigint", nullable: false),
                    ProposerId = table.Column<long>(type: "bigint", nullable: false),
                    ProposeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeDiscipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDiscipline_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDiscipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDiscipline_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDiscipline_ProposerId",
                        column: x => x.ProposerId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EducationId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    MajorId = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    RankingId = table.Column<long>(type: "bigint", nullable: false),
                    ModelOfStudyId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_EducationId",
                        column: x => x.EducationId,
                        principalSchema: "dbo",
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_MajorId",
                        column: x => x.MajorId,
                        principalSchema: "dbo",
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_ModelOfStudyId",
                        column: x => x.ModelOfStudyId,
                        principalSchema: "dbo",
                        principalTable: "ModelOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_RankingId",
                        column: x => x.RankingId,
                        principalSchema: "dbo",
                        principalTable: "Ranking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "dbo",
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdentification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PlaceId = table.Column<long>(type: "bigint", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentificationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatusId = table.Column<long>(type: "bigint", nullable: true),
                    ReligionId = table.Column<long>(type: "bigint", nullable: true),
                    EthnicityId = table.Column<long>(type: "bigint", nullable: true),
                    NationalityId = table.Column<long>(type: "bigint", nullable: true),
                    AcademicLevelId = table.Column<long>(type: "bigint", nullable: true),
                    ProfessionalQualificationId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_EthnicityId",
                        column: x => x.EthnicityId,
                        principalSchema: "dbo",
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalSchema: "dbo",
                        principalTable: "MaritalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "dbo",
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_ProfessionalQualificationId",
                        column: x => x.ProfessionalQualificationId,
                        principalSchema: "dbo",
                        principalTable: "ProfessionalQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_ReligionId",
                        column: x => x.ReligionId,
                        principalSchema: "dbo",
                        principalTable: "Religion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLeave",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    LeaveTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LeaveStatus = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LineManagerId = table.Column<long>(type: "bigint", nullable: false),
                    CarbonCopy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ApproverId = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_ApproverId",
                        column: x => x.ApproverId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "dbo",
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_LineManagerId",
                        column: x => x.LineManagerId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLeaveSetting",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    NumOfDay = table.Column<float>(type: "real", nullable: false),
                    DayUsed = table.Column<float>(type: "real", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeaveSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLeaveSetting_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRelationship",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RelationshipTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    table.PrimaryKey("PK_EmployeeRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRelationship_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeRelationship_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalSchema: "dbo",
                        principalTable: "RelationshipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ward_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Skyper = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Zalo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Facebook = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    LinkedIn = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Twitter = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Github = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Whatsapp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TemporaryWardId = table.Column<long>(type: "bigint", nullable: true),
                    TemporaryDistrictId = table.Column<long>(type: "bigint", nullable: true),
                    TemporaryProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PermanentWardId = table.Column<long>(type: "bigint", nullable: true),
                    PermanentDistrictId = table.Column<long>(type: "bigint", nullable: true),
                    PermanentProvinceId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContact_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContact_Ward_TemporaryWardId",
                        column: x => x.TemporaryWardId,
                        principalSchema: "dbo",
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                schema: "dbo",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CurrentDepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "CurrentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CurrentPositionId",
                schema: "dbo",
                table: "Employee",
                column: "CurrentPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeWorkingStatusId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeWorkingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBank_BankId",
                schema: "dbo",
                table: "EmployeeBank",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBank_EmployeeId",
                schema: "dbo",
                table: "EmployeeBank",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificate_CertificatedId",
                schema: "dbo",
                table: "EmployeeCertificate",
                column: "CertificatedId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificate_EmployeeId",
                schema: "dbo",
                table: "EmployeeCertificate",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificate_SchoolId",
                schema: "dbo",
                table: "EmployeeCertificate",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommendation_ApprovedBy",
                schema: "dbo",
                table: "EmployeeCommendation",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommendation_CommendationId",
                schema: "dbo",
                table: "EmployeeCommendation",
                column: "CommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommendation_EmployeeId",
                schema: "dbo",
                table: "EmployeeCommendation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommendation_ProposerId",
                schema: "dbo",
                table: "EmployeeCommendation",
                column: "ProposerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContact_EmployeeId",
                schema: "dbo",
                table: "EmployeeContact",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContact_TemporaryWardId",
                schema: "dbo",
                table: "EmployeeContact",
                column: "TemporaryWardId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContract_ContractTypeId",
                schema: "dbo",
                table: "EmployeeContract",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContract_EmployeeId",
                schema: "dbo",
                table: "EmployeeContract",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContract_EmployeeProcessId",
                schema: "dbo",
                table: "EmployeeContract",
                column: "EmployeeProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependency_EmployeeId",
                schema: "dbo",
                table: "EmployeeDependency",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependency_RelationshipTypeId",
                schema: "dbo",
                table: "EmployeeDependency",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDiscipline_ApprovedBy",
                schema: "dbo",
                table: "EmployeeDiscipline",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDiscipline_DisciplineId",
                schema: "dbo",
                table: "EmployeeDiscipline",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDiscipline_EmployeeId",
                schema: "dbo",
                table: "EmployeeDiscipline",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDiscipline_ProposerId",
                schema: "dbo",
                table: "EmployeeDiscipline",
                column: "ProposerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_EducationId",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_EmployeeId",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_MajorId",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_ModelOfStudyId",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "ModelOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_RankingId",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_SchoolId",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "SchoolId");

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_EmployeeId",
                schema: "dbo",
                table: "EmployeeInfo",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_EthnicityId",
                schema: "dbo",
                table: "EmployeeInfo",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_MaritalStatusId",
                schema: "dbo",
                table: "EmployeeInfo",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_NationalityId",
                schema: "dbo",
                table: "EmployeeInfo",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_ProfessionalQualificationId",
                schema: "dbo",
                table: "EmployeeInfo",
                column: "ProfessionalQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_ReligionId",
                schema: "dbo",
                table: "EmployeeInfo",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_ApproverId",
                schema: "dbo",
                table: "EmployeeLeave",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_EmployeeId",
                schema: "dbo",
                table: "EmployeeLeave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_LeaveTypeId",
                schema: "dbo",
                table: "EmployeeLeave",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_LineManagerId",
                schema: "dbo",
                table: "EmployeeLeave",
                column: "LineManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveSetting_EmployeeId",
                schema: "dbo",
                table: "EmployeeLeaveSetting",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRelationship_EmployeeId",
                schema: "dbo",
                table: "EmployeeRelationship",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRelationship_RelationshipTypeId",
                schema: "dbo",
                table: "EmployeeRelationship",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictId",
                schema: "dbo",
                table: "Ward",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeBank",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeCertificate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeCommendation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeContact",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeContract",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeDependency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeDiscipline",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeEducation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeIdentification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeLeave",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeLeaveSetting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeRelationship",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "File",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bank",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Certificated",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Commendation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ward",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContractType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Education",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Major",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ModelOfStudy",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ranking",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "School",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IdentificationType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ethnicity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MaritalStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nationality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProfessionalQualification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Religion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LeaveType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RelationshipType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "District",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeWorkingStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Province",
                schema: "dbo");
        }
    }
}
