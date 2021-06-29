using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrus.Migrations
{
    public partial class ytt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Contact_ContactId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ContactId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_StudentId",
                table: "Contact",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Students_StudentId",
                table: "Contact",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Students_StudentId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_StudentId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ContactId",
                table: "Students",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Contact_ContactId",
                table: "Students",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
