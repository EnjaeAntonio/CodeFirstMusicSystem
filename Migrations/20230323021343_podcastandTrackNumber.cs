using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstMusicSystem.Migrations
{
    public partial class podcastandTrackNumber : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "TrackSong",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AddListenerListViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    ListenerListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddListenerListViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestArtists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastArtists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddListenerListViewModelId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Podcast_AddListenerListViewModel_AddListenerListViewModelId",
                        column: x => x.AddListenerListViewModelId,
                        principalTable: "AddListenerListViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    GuestArtistId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_GuestArtists_GuestArtistId",
                        column: x => x.GuestArtistId,
                        principalTable: "GuestArtists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Episode_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListenerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddListenerListViewModelId = table.Column<int>(type: "int", nullable: true),
                    PodcastId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenerList_AddListenerListViewModel_AddListenerListViewModelId",
                        column: x => x.AddListenerListViewModelId,
                        principalTable: "AddListenerListViewModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListenerList_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PodcastCastArtists",
                columns: table => new
                {
                    PodcastArtistId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastCastArtists", x => new { x.PodcastArtistId, x.PodcastId });
                    table.ForeignKey(
                        name: "FK_PodcastCastArtists_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastCastArtists_PodcastArtists_PodcastArtistId",
                        column: x => x.PodcastArtistId,
                        principalTable: "PodcastArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestArtistEpisodes",
                columns: table => new
                {
                    GuestArtistId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestArtistEpisodes", x => new { x.GuestArtistId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_GuestArtistEpisodes_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestArtistEpisodes_GuestArtists_GuestArtistId",
                        column: x => x.GuestArtistId,
                        principalTable: "GuestArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastListenerLists",
                columns: table => new
                {
                    ListenerListId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastListenerLists", x => new { x.ListenerListId, x.PodcastId });
                    table.ForeignKey(
                        name: "FK_PodcastListenerLists_ListenerList_ListenerListId",
                        column: x => x.ListenerListId,
                        principalTable: "ListenerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastListenerLists_Podcast_PodcastId",
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
                name: "IX_GuestArtistEpisodes_EpisodeId",
                table: "GuestArtistEpisodes",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerList_AddListenerListViewModelId",
                table: "ListenerList",
                column: "AddListenerListViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerList_PodcastId",
                table: "ListenerList",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcast_AddListenerListViewModelId",
                table: "Podcast",
                column: "AddListenerListViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastCastArtists_PodcastId",
                table: "PodcastCastArtists",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastListenerLists_PodcastId",
                table: "PodcastListenerLists",
                column: "PodcastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestArtistEpisodes");

            migrationBuilder.DropTable(
                name: "PodcastCastArtists");

            migrationBuilder.DropTable(
                name: "PodcastListenerLists");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "PodcastArtists");

            migrationBuilder.DropTable(
                name: "ListenerList");

            migrationBuilder.DropTable(
                name: "GuestArtists");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.DropTable(
                name: "AddListenerListViewModel");

            migrationBuilder.DropColumn(
                name: "TrackSong",
                table: "Song");

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
