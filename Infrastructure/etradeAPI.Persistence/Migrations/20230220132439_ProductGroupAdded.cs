using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace etradeAPI.Persistence.Migrations
{
    public partial class ProductGroupAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductGroupId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductGroupId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId1",
                table: "Products",
                column: "ProductGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroup_ProductGroupId1",
                table: "Products",
                column: "ProductGroupId1",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroup_ProductGroupId1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupId1",
                table: "Products");
        }
    }
}
