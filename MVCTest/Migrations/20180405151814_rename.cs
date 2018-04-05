using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MVCTest.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "like",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "imageId",
                table: "Likes",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Images",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Images",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "hidden",
                table: "Images",
                newName: "Hidden");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Images",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Comments",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "imageId",
                table: "Comments",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "Comments",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comments",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Likes",
                newName: "imageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Likes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Images",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Hidden",
                table: "Images",
                newName: "hidden");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Comments",
                newName: "imageId");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Comments",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "like",
                table: "Images",
                nullable: false,
                defaultValue: 0);
        }
    }
}
