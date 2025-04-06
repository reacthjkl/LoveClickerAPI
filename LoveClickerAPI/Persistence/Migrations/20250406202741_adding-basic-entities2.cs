using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingbasicentities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Inventories_InventoryId",
                table: "UserItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Users_UserId",
                table: "UserItems");

            migrationBuilder.DropIndex(
                name: "IX_UserItems_UserId",
                table: "UserItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "InventoryId",
                table: "UserItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Inventories_InventoryId",
                table: "UserItems",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Inventories_InventoryId",
                table: "UserItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "InventoryId",
                table: "UserItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_UserId",
                table: "UserItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Inventories_InventoryId",
                table: "UserItems",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Users_UserId",
                table: "UserItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
