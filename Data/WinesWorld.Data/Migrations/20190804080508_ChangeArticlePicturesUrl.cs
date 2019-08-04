using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinesWorld.Data.Migrations
{
    public partial class ChangeArticlePicturesUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ArticlePictures");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ArticlePictures");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ArticlePictures",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ArticlePictures",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ArticlePictures",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "ArticlePictures",
                nullable: true);
        }
    }
}
