using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinesWorld.Data.Migrations
{
    public partial class ForgotByteArrayInArticlePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "ArticlePictures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ArticlePictures");
        }
    }
}
