using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFO4042___Projet_Final.Migrations
{
    /// <inheritdoc />
    public partial class OptionalCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Category_CategoryId",
                table: "Contact");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Contact",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Category_CategoryId",
                table: "Contact",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Category_CategoryId",
                table: "Contact");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Category_CategoryId",
                table: "Contact",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
