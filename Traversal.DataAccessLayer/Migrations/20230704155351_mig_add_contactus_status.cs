using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traversal.DataAccessLayer.Migrations
{
    public partial class mig_add_contactus_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MessageStatus",
                table: "ContactsUses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "ContactsUses");
        }
    }
}
