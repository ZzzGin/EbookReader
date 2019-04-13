using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EbookReader.Data.Migrations
{
    public partial class modelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookShelfDbSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookShelfName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelfDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookShelfDbSet_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookDbSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookName = table.Column<string>(nullable: true),
                    BookCoverImagePath = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    UploadedDateTime = table.Column<DateTime>(nullable: false),
                    UploadedByUserId = table.Column<string>(nullable: true),
                    BookShelfModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookDbSet_BookShelfDbSet_BookShelfModelId",
                        column: x => x.BookShelfModelId,
                        principalTable: "BookShelfDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookDbSet_AspNetUsers_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecommendationStars = table.Column<byte>(nullable: false),
                    CommentContent = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    CreateByUserId1 = table.Column<string>(nullable: true),
                    BookId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentDbSet_BookDbSet_BookId",
                        column: x => x.BookId,
                        principalTable: "BookDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentDbSet_AspNetUsers_CreateByUserId1",
                        column: x => x.CreateByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteDbSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    CreateByUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteDbSet_BookDbSet_BookId",
                        column: x => x.BookId,
                        principalTable: "BookDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteDbSet_AspNetUsers_CreateByUserId1",
                        column: x => x.CreateByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookDbSet_BookShelfModelId",
                table: "BookDbSet",
                column: "BookShelfModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookDbSet_UploadedByUserId",
                table: "BookDbSet",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfDbSet_UserId1",
                table: "BookShelfDbSet",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDbSet_BookId",
                table: "CommentDbSet",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDbSet_CreateByUserId1",
                table: "CommentDbSet",
                column: "CreateByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteDbSet_BookId",
                table: "NoteDbSet",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteDbSet_CreateByUserId1",
                table: "NoteDbSet",
                column: "CreateByUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentDbSet");

            migrationBuilder.DropTable(
                name: "NoteDbSet");

            migrationBuilder.DropTable(
                name: "BookDbSet");

            migrationBuilder.DropTable(
                name: "BookShelfDbSet");
        }
    }
}
