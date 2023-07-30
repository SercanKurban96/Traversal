using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traversal.DataAccessLayer.Migrations
{
    public partial class mig_add_date_destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DestinationDate",
                table: "Destinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationDate",
                table: "Destinations");
        }
    }
}
