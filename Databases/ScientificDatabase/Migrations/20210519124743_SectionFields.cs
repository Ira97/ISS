using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificDatabase.Migrations
{
    public partial class SectionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Sections",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Sections");
        }
    }
}
