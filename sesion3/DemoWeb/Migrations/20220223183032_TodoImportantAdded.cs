using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWeb.Migrations
{
    public partial class TodoImportantAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Important",
                table: "Todos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Important",
                table: "Todos");
        }
    }
}
