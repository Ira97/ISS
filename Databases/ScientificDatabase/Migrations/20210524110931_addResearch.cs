using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificDatabase.Migrations
{
    public partial class addResearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Research",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Research", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Research_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataObjectResearch",
                columns: table => new
                {
                    DataObjectsId = table.Column<int>(type: "int", nullable: false),
                    ResearchesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataObjectResearch", x => new { x.DataObjectsId, x.ResearchesId });
                    table.ForeignKey(
                        name: "FK_DataObjectResearch_DataObjects_DataObjectsId",
                        column: x => x.DataObjectsId,
                        principalTable: "DataObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataObjectResearch_Research_ResearchesId",
                        column: x => x.ResearchesId,
                        principalTable: "Research",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataObjectResearch_ResearchesId",
                table: "DataObjectResearch",
                column: "ResearchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Research_SectionId",
                table: "Research",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataObjectResearch");

            migrationBuilder.DropTable(
                name: "Research");
        }
    }
}
