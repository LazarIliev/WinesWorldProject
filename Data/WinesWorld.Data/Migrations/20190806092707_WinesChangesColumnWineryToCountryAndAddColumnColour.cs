using Microsoft.EntityFrameworkCore.Migrations;

namespace WinesWorld.Data.Migrations
{
    public partial class WinesChangesColumnWineryToCountryAndAddColumnColour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Winery",
                table: "Wines",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Wines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Wines");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Wines",
                newName: "Winery");
        }
    }
}
