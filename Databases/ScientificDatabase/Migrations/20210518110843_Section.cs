using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificDatabase.Migrations
{
    public partial class Section : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AresId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AresId",
                table: "Sections");
        }
    }
}
