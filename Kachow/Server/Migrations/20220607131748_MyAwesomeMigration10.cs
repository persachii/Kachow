using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kachow.Server.Migrations
{
    public partial class MyAwesomeMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "parcel_names",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "parcel_names");
        }
    }
}
