using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRideTrackerWebApp.Migrations
{
    public partial class AddedServiceBoolFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Service",
                table: "Rides",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "Rides");
        }
    }
}
