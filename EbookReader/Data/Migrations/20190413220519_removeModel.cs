using Microsoft.EntityFrameworkCore.Migrations;

namespace EbookReader.Data.Migrations
{
    public partial class removeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "NoteDbSet",
                newName: "NoteContent");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "NoteDbSet",
                newName: "BookContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteContent",
                table: "NoteDbSet",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "BookContent",
                table: "NoteDbSet",
                newName: "Content");
        }
    }
}
