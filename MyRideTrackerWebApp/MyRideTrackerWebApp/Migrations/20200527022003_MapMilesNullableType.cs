using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRideTrackerWebApp.Migrations
{
    public partial class MapMilesNullableType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MapMiles",
                table: "Rides",
                type: "decimal(8, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MapMiles",
                table: "Rides",
                type: "decimal(8, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)",
                oldNullable: true);
        }
    }
}
