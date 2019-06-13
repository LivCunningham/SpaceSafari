using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceSafari.Migrations
{
    public partial class species_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diet",
                table: "AlienTypes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AlienTypes",
                newName: "Species");

            migrationBuilder.RenameColumn(
                name: "Mating",
                table: "AlienTypes",
                newName: "LocationOfLastSeen");

            migrationBuilder.AddColumn<int>(
                name: "CountOfTimesSeen",
                table: "AlienTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfTimesSeen",
                table: "AlienTypes");

            migrationBuilder.RenameColumn(
                name: "Species",
                table: "AlienTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LocationOfLastSeen",
                table: "AlienTypes",
                newName: "Mating");

            migrationBuilder.AddColumn<string>(
                name: "Diet",
                table: "AlienTypes",
                nullable: true);
        }
    }
}
