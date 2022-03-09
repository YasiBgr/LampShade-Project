using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagment.Infrastructure.efCore.Migrations
{
    public partial class LinkAddedToSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Slide",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Slide");
        }
    }
}
