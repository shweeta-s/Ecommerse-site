using Microsoft.EntityFrameworkCore.Migrations;

namespace POC.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cart_id);
                });

          

           
           

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    cart_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    cart_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_Item_Cart_cart_id1",
                        column: x => x.cart_id1,
                        principalTable: "Cart",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_cart_id1",
                table: "Item",
                column: "cart_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Item");

          
            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
