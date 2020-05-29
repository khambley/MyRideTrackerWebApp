using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRideTrackerWebApp.Migrations
{
    public partial class AddedMilesPerGallonColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MilesPerGallon",
                table: "Rides",
                type: "decimal(8, 2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MilesPerGallon",
                table: "Rides");
        }
    }
}
