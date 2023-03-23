using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeFirstMusicSystem.Models;

namespace CodeFirstMusicSystem.Data
{
    public class CodeFirstMusicSystemContext : DbContext
    {
        public CodeFirstMusicSystemContext (DbContextOptions<CodeFirstMusicSystemContext> options)
            : base(options)
        {
        }

        protected void OnModelCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>()
                .HasDiscriminator<string>("media_type")
                .HasValue<Song>("media_song")
                .HasValue<Episode>("media_episode");

            modelBuilder.Entity<MediaCollection>()
                .HasDiscriminator<string>("mediacollection_type")
                .HasValue<Album>("mediacollection_album")
                .HasValue<Podcast>("mediacollection_podcast");
        }

        public DbSet<CodeFirstMusicSystem.Models.Song> Song { get; set; } = default!;
        public DbSet<Album> Albums { get; set; } = default!;

        public DbSet<Episode> Episodes { get; set; }  = default!;

    }
}
