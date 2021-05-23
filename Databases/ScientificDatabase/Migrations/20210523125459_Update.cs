using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificDatabase.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataObjects_TypeObjects_TypeObjectId",
                table: "DataObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuePropertyObjects_DataObjects_DataObjectId",
                table: "ValuePropertyObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuePropertyObjects_Properties_PropertyId",
                table: "ValuePropertyObjects");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "ValuePropertyObjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DataObjectId",
                table: "ValuePropertyObjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeObjectId",
                table: "DataObjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataObjects_TypeObjects_TypeObjectId",
                table: "DataObjects",
                column: "TypeObjectId",
                principalTable: "TypeObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValuePropertyObjects_DataObjects_DataObjectId",
                table: "ValuePropertyObjects",
                column: "DataObjectId",
                principalTable: "DataObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValuePropertyObjects_Properties_PropertyId",
                table: "ValuePropertyObjects",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataObjects_TypeObjects_TypeObjectId",
                table: "DataObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuePropertyObjects_DataObjects_DataObjectId",
                table: "ValuePropertyObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuePropertyObjects_Properties_PropertyId",
                table: "ValuePropertyObjects");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "ValuePropertyObjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DataObjectId",
                table: "ValuePropertyObjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeObjectId",
                table: "DataObjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DataObjects_TypeObjects_TypeObjectId",
                table: "DataObjects",
                column: "TypeObjectId",
                principalTable: "TypeObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValuePropertyObjects_DataObjects_DataObjectId",
                table: "ValuePropertyObjects",
                column: "DataObjectId",
                principalTable: "DataObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValuePropertyObjects_Properties_PropertyId",
                table: "ValuePropertyObjects",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
