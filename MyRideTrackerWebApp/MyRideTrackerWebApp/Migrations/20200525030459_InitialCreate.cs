using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRideTrackerWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    RideId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RideDate = table.Column<DateTime>(nullable: false),
                    MileageStart = table.Column<int>(nullable: false),
                    MileageEnd = table.Column<int>(nullable: false),
                    TotalMiles = table.Column<int>(nullable: false),
                    FillUp = table.Column<bool>(nullable: false),
                    Gallons = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    PricePerGallon = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    RideRoute = table.Column<string>(nullable: true),
                    RideDescription = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.RideId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rides");
        }
    }
}
