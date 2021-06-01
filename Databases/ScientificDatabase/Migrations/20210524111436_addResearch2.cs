using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificDatabase.Migrations
{
    public partial class addResearch2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataObjectResearch_Research_ResearchesId",
                table: "DataObjectResearch");

            migrationBuilder.DropForeignKey(
                name: "FK_Research_Sections_SectionId",
                table: "Research");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Research",
                table: "Research");

            migrationBuilder.RenameTable(
                name: "Research",
                newName: "Researches");

            migrationBuilder.RenameIndex(
                name: "IX_Research_SectionId",
                table: "Researches",
                newName: "IX_Researches_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Researches",
                table: "Researches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataObjectResearch_Researches_ResearchesId",
                table: "DataObjectResearch",
                column: "ResearchesId",
                principalTable: "Researches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Sections_SectionId",
                table: "Researches",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataObjectResearch_Researches_ResearchesId",
                table: "DataObjectResearch");

            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Sections_SectionId",
                table: "Researches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Researches",
                table: "Researches");

            migrationBuilder.RenameTable(
                name: "Researches",
                newName: "Research");

            migrationBuilder.RenameIndex(
                name: "IX_Researches_SectionId",
                table: "Research",
                newName: "IX_Research_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Research",
                table: "Research",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataObjectResearch_Research_ResearchesId",
                table: "DataObjectResearch",
                column: "ResearchesId",
                principalTable: "Research",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Research_Sections_SectionId",
                table: "Research",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
