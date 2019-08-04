using Microsoft.EntityFrameworkCore.Migrations;

namespace WinesWorld.Data.Migrations
{
    public partial class ArticleRelationListOfArticlePictureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleId",
                table: "ArticlePictures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePictures_ArticleId",
                table: "ArticlePictures",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePictures_Articles_ArticleId",
                table: "ArticlePictures",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePictures_Articles_ArticleId",
                table: "ArticlePictures");

            migrationBuilder.DropIndex(
                name: "IX_ArticlePictures_ArticleId",
                table: "ArticlePictures");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "ArticlePictures");
        }
    }
}
