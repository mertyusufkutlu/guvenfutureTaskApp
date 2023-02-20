using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace etradeAPI.Persistence.Migrations
{
    public partial class ProductGroup_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroup_ProductGroupId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupId1",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGroupId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroup_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroup_ProductGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ProductGroupId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductGroupId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
