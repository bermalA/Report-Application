using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoxaFinal.Migrations
{
    /// <inheritdoc />
    public partial class devmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DocumentData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DocUploadTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    MovementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    PackageNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.MovementId);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PartCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PartLogicalRef = table.Column<int>(type: "int", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    NetAmount = table.Column<int>(type: "int", nullable: true),
                    NetHeight = table.Column<int>(type: "int", nullable: true),
                    NetWidth = table.Column<int>(type: "int", nullable: true),
                    RoughAmount = table.Column<int>(type: "int", nullable: true),
                    RoughHeight = table.Column<int>(type: "int", nullable: true),
                    RoughWidth = table.Column<int>(type: "int", nullable: true),
                    ProductAmount = table.Column<int>(type: "int", nullable: true),
                    PVCType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PVCHeight = table.Column<int>(type: "int", nullable: true),
                    PVCWidth = table.Column<int>(type: "int", nullable: true),
                    Options = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OptHeight = table.Column<int>(type: "int", nullable: true),
                    OptWidth = table.Column<int>(type: "int", nullable: true),
                    PartDescription = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionId = table.Column<int>(type: "int", nullable: false),
                    ReceiptName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReceiptCode = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ActiveUser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
