using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstMusicSystem.Migrations
{
    public partial class podcastss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Song",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "GuestArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestArtist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastArtist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestArtistId = table.Column<int>(type: "int", nullable: true),
                    PodcastId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_GuestArtist_GuestArtistId",
                        column: x => x.GuestArtistId,
                        principalTable: "GuestArtist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Episode_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListenerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenerList_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PodcastCastArtist",
                columns: table => new
                {
                    PodcastArtistId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastCastArtist", x => new { x.PodcastArtistId, x.PodcastId });
                    table.ForeignKey(
                        name: "FK_PodcastCastArtist_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastCastArtist_PodcastArtist_PodcastArtistId",
                        column: x => x.PodcastArtistId,
                        principalTable: "PodcastArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestArtistEpisode",
                columns: table => new
                {
                    GuestArtistId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestArtistEpisode", x => new { x.GuestArtistId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_GuestArtistEpisode_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestArtistEpisode_GuestArtist_GuestArtistId",
                        column: x => x.GuestArtistId,
                        principalTable: "GuestArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastListenerList",
                columns: table => new
                {
                    ListenerListId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastListenerList", x => new { x.ListenerListId, x.PodcastId });
                    table.ForeignKey(
                        name: "FK_PodcastListenerList_ListenerList_ListenerListId",
                        column: x => x.ListenerListId,
                        principalTable: "ListenerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastListenerList_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_GuestArtistId",
                table: "Episode",
                column: "GuestArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_PodcastId",
                table: "Episode",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestArtistEpisode_EpisodeId",
                table: "GuestArtistEpisode",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerList_PodcastId",
                table: "ListenerList",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastCastArtist_PodcastId",
                table: "PodcastCastArtist",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastListenerList_PodcastId",
                table: "PodcastListenerList",
                column: "PodcastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestArtistEpisode");

            migrationBuilder.DropTable(
                name: "PodcastCastArtist");

            migrationBuilder.DropTable(
                name: "PodcastListenerList");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "PodcastArtist");

            migrationBuilder.DropTable(
                name: "ListenerList");

            migrationBuilder.DropTable(
                name: "GuestArtist");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
