using Microsoft.EntityFrameworkCore.Migrations;

namespace PostServiceBackEnd.Migrations
{
    public partial class addReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverFullName",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverFullName",
                table: "Parcels");
        }
    }
}
