using Microsoft.EntityFrameworkCore.Migrations;

namespace POC.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Cart_cart_id1",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_cart_id1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "cart_id1",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cart_id1",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_cart_id1",
                table: "Item",
                column: "cart_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Cart_cart_id1",
                table: "Item",
                column: "cart_id1",
                principalTable: "Cart",
                principalColumn: "cart_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
