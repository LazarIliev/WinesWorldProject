using Microsoft.EntityFrameworkCore.Migrations;

namespace WinesWorld.Data.Migrations
{
    public partial class AddPriceInWine_AddArticlePictureEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Wines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ArticlePictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlePictures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlePictures");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Wines");
        }
    }
}
