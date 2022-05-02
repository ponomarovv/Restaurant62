using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant62.DAL.Impl.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Potion",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Potion",
                table: "Dishes");
        }
    }
}
