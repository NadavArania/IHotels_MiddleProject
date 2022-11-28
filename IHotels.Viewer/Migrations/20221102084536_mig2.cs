using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IHotels.Viewer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastOrder",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NumberOfOrder",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TotalOrder",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SpeicalRequirment",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastOrder",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfOrder",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalOrder",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SpeicalRequirment",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
