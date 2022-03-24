using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagment.Infrastructure.efCore.Migrations
{
    public partial class addingStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comment");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
