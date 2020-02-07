using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWish.Library.Migrations
{
    public partial class MediaWishDBmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wishLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaTitle = table.Column<string>(nullable: true),
                    MediaPlatform = table.Column<string>(nullable: true),
                    MediaDescription = table.Column<string>(nullable: true),
                    mediasId = table.Column<int>(nullable: true),
                    usersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wishLists_medias_mediasId",
                        column: x => x.mediasId,
                        principalTable: "medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_wishLists_users_usersId",
                        column: x => x.usersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_wishLists_mediasId",
                table: "wishLists",
                column: "mediasId");

            migrationBuilder.CreateIndex(
                name: "IX_wishLists_usersId",
                table: "wishLists",
                column: "usersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wishLists");

            migrationBuilder.DropTable(
                name: "medias");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
