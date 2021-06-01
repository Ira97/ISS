using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificDatabase.Migrations
{
    public partial class NewPropertiesForResearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "Researches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Object",
                table: "Researches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thing",
                table: "Researches",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "Object",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "Thing",
                table: "Researches");
        }
    }
}
