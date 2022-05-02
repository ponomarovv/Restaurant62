using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant62.DAL.Impl.Migrations
{
    public partial class twoEntitiesFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.AddColumn<int>(
                name: "DishOrderId",
                table: "DishOrders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DishIngredientId",
                table: "DishIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders",
                column: "DishOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                column: "DishIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_DishId",
                table: "DishOrders",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_DishId",
                table: "DishIngredients",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_DishOrders_DishId",
                table: "DishOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.DropIndex(
                name: "IX_DishIngredients_DishId",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "DishOrderId",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "DishIngredientId",
                table: "DishIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" });
        }
    }
}
