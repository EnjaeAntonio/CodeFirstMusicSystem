﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstMusicSystem.Migrations
{
    public partial class artistindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Album",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Album");
        }
    }
}
