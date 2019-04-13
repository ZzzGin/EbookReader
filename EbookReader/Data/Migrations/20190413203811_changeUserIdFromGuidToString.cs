using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EbookReader.Data.Migrations
{
    public partial class changeUserIdFromGuidToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelfDbSet_AspNetUsers_UserId1",
                table: "BookShelfDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentDbSet_AspNetUsers_CreateByUserId1",
                table: "CommentDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteDbSet_AspNetUsers_CreateByUserId1",
                table: "NoteDbSet");

            migrationBuilder.DropIndex(
                name: "IX_NoteDbSet_CreateByUserId1",
                table: "NoteDbSet");

            migrationBuilder.DropIndex(
                name: "IX_CommentDbSet_CreateByUserId1",
                table: "CommentDbSet");

            migrationBuilder.DropColumn(
                name: "CreateByUserId1",
                table: "NoteDbSet");

            migrationBuilder.DropColumn(
                name: "CreateByUserId1",
                table: "CommentDbSet");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookShelfDbSet");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "BookShelfDbSet",
                newName: "CreateByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookShelfDbSet_UserId1",
                table: "BookShelfDbSet",
                newName: "IX_BookShelfDbSet_CreateByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "CreateByUserId",
                table: "NoteDbSet",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "CreateByUserId",
                table: "CommentDbSet",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_NoteDbSet_CreateByUserId",
                table: "NoteDbSet",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDbSet_CreateByUserId",
                table: "CommentDbSet",
                column: "CreateByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelfDbSet_AspNetUsers_CreateByUserId",
                table: "BookShelfDbSet",
                column: "CreateByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentDbSet_AspNetUsers_CreateByUserId",
                table: "CommentDbSet",
                column: "CreateByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDbSet_AspNetUsers_CreateByUserId",
                table: "NoteDbSet",
                column: "CreateByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelfDbSet_AspNetUsers_CreateByUserId",
                table: "BookShelfDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentDbSet_AspNetUsers_CreateByUserId",
                table: "CommentDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteDbSet_AspNetUsers_CreateByUserId",
                table: "NoteDbSet");

            migrationBuilder.DropIndex(
                name: "IX_NoteDbSet_CreateByUserId",
                table: "NoteDbSet");

            migrationBuilder.DropIndex(
                name: "IX_CommentDbSet_CreateByUserId",
                table: "CommentDbSet");

            migrationBuilder.RenameColumn(
                name: "CreateByUserId",
                table: "BookShelfDbSet",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_BookShelfDbSet_CreateByUserId",
                table: "BookShelfDbSet",
                newName: "IX_BookShelfDbSet_UserId1");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateByUserId",
                table: "NoteDbSet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUserId1",
                table: "NoteDbSet",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateByUserId",
                table: "CommentDbSet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUserId1",
                table: "CommentDbSet",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BookShelfDbSet",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NoteDbSet_CreateByUserId1",
                table: "NoteDbSet",
                column: "CreateByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDbSet_CreateByUserId1",
                table: "CommentDbSet",
                column: "CreateByUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelfDbSet_AspNetUsers_UserId1",
                table: "BookShelfDbSet",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentDbSet_AspNetUsers_CreateByUserId1",
                table: "CommentDbSet",
                column: "CreateByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDbSet_AspNetUsers_CreateByUserId1",
                table: "NoteDbSet",
                column: "CreateByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
