using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameTest.DataAccess.Migrations
{
    public partial class addGamePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GamePicture",
                table: "VideoGame",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamePicture",
                table: "VideoGame");
        }
    }
}
