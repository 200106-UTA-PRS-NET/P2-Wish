using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWish.Library.Migrations
{
    public partial class updatingdatabasebacktooriginal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "wishLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "wishLists",
                type: "int",
                nullable: true);
        }
    }
}
