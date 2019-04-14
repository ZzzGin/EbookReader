using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EbookReader.Data.Migrations
{
    public partial class AddPKinJoinModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinBookShelfBookDbSet",
                table: "JoinBookShelfBookDbSet");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JoinBookShelfBookDbSet",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinBookShelfBookDbSet",
                table: "JoinBookShelfBookDbSet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JoinBookShelfBookDbSet_BookId",
                table: "JoinBookShelfBookDbSet",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinBookShelfBookDbSet",
                table: "JoinBookShelfBookDbSet");

            migrationBuilder.DropIndex(
                name: "IX_JoinBookShelfBookDbSet_BookId",
                table: "JoinBookShelfBookDbSet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JoinBookShelfBookDbSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinBookShelfBookDbSet",
                table: "JoinBookShelfBookDbSet",
                columns: new[] { "BookId", "BookShelfId" });
        }
    }
}
