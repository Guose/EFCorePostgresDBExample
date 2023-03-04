using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NinjaDomain.WebApi.Migrations
{
    public partial class AddingNinjaAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Ninjas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Ninjas");
        }
    }
}
