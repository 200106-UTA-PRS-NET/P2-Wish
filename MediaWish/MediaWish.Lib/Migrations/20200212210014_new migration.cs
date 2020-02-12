using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWish.Library.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishLists_medias_mediasId",
                table: "wishLists");

            migrationBuilder.DropIndex(
                name: "IX_wishLists_mediasId",
                table: "wishLists");

            migrationBuilder.DropColumn(
                name: "mediasId",
                table: "wishLists");

            migrationBuilder.AddColumn<int>(
                name: "MediaID",
                table: "wishLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mediaTypesId",
                table: "wishLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_wishLists_mediaTypesId",
                table: "wishLists",
                column: "mediaTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_wishLists_medias_mediaTypesId",
                table: "wishLists",
                column: "mediaTypesId",
                principalTable: "medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishLists_medias_mediaTypesId",
                table: "wishLists");

            migrationBuilder.DropIndex(
                name: "IX_wishLists_mediaTypesId",
                table: "wishLists");

            migrationBuilder.DropColumn(
                name: "MediaID",
                table: "wishLists");

            migrationBuilder.DropColumn(
                name: "mediaTypesId",
                table: "wishLists");

            migrationBuilder.AddColumn<int>(
                name: "mediasId",
                table: "wishLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_wishLists_mediasId",
                table: "wishLists",
                column: "mediasId");

            migrationBuilder.AddForeignKey(
                name: "FK_wishLists_medias_mediasId",
                table: "wishLists",
                column: "mediasId",
                principalTable: "medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
