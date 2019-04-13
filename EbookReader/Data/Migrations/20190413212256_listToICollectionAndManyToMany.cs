using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EbookReader.Data.Migrations
{
    public partial class listToICollectionAndManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDbSet_BookShelfDbSet_BookShelfModelId",
                table: "BookDbSet");

            migrationBuilder.DropIndex(
                name: "IX_BookDbSet_BookShelfModelId",
                table: "BookDbSet");

            migrationBuilder.DropColumn(
                name: "BookShelfModelId",
                table: "BookDbSet");

            migrationBuilder.CreateTable(
                name: "JoinBookShelfBookDbSet",
                columns: table => new
                {
                    BookShelfId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinBookShelfBookDbSet", x => new { x.BookId, x.BookShelfId });
                    table.ForeignKey(
                        name: "FK_JoinBookShelfBookDbSet_BookDbSet_BookId",
                        column: x => x.BookId,
                        principalTable: "BookDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinBookShelfBookDbSet_BookShelfDbSet_BookShelfId",
                        column: x => x.BookShelfId,
                        principalTable: "BookShelfDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinBookShelfBookDbSet_BookShelfId",
                table: "JoinBookShelfBookDbSet",
                column: "BookShelfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinBookShelfBookDbSet");

            migrationBuilder.AddColumn<Guid>(
                name: "BookShelfModelId",
                table: "BookDbSet",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookDbSet_BookShelfModelId",
                table: "BookDbSet",
                column: "BookShelfModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDbSet_BookShelfDbSet_BookShelfModelId",
                table: "BookDbSet",
                column: "BookShelfModelId",
                principalTable: "BookShelfDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
