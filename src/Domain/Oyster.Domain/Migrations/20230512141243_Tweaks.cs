using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oyster.Domain.Migrations
{
    public partial class Tweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "TrashBins");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "TrashBins");

            migrationBuilder.AddColumn<string>(
                name: "SensorSerialNumber",
                table: "TrashBins",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorSerialNumber",
                table: "TrashBins");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "TrashBins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "TrashBins",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
