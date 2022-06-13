using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMySQL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "friend",
                columns: table => new
                {
                    friend_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    post_code = table.Column<string>(type: "TEXT", nullable: false),
                    home_phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friend", x => x.friend_id);
                });

            migrationBuilder.CreateTable(
                name: "video_collection",
                columns: table => new
                {
                    video_collection_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    movie_title = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    year_released = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    friend_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_collection", x => x.video_collection_id);
                    table.ForeignKey(
                        name: "FK_video_collection_friend_friend_id",
                        column: x => x.friend_id,
                        principalTable: "friend",
                        principalColumn: "friend_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "friend",
                columns: new[] { "friend_id", "Address", "City", "FirstName", "home_phone", "LastName", "post_code", "State" },
                values: new object[] { 1, "Thimi", "huusdfb", "sdfasw", "12345678", "terei", "12345", "3" });

            migrationBuilder.InsertData(
                table: "video_collection",
                columns: new[] { "video_collection_id", "friend_id", "Length", "movie_title", "Note", "Rating", "Subject", "year_released" },
                values: new object[] { 1, 1, 2.5, "This is bull", null, 4.5, "", 2020 });

            migrationBuilder.CreateIndex(
                name: "IX_video_collection_friend_id",
                table: "video_collection",
                column: "friend_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "video_collection");

            migrationBuilder.DropTable(
                name: "friend");
        }
    }
}
