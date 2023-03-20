using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeFirstMusicSystem.Models;
using CodeFirstMusicSystem.Models.Viewmodel;

namespace CodeFirstMusicSystem.Data
{
    public class MusicSystemContext : DbContext
    {
        public MusicSystemContext (DbContextOptions<MusicSystemContext> options)
            : base(options)
        {
        }

        public DbSet<CodeFirstMusicSystem.Models.Album> Album { get; set; } = default!;

        public DbSet<CodeFirstMusicSystem.Models.Artist> Artist { get; set; }

        public DbSet<CodeFirstMusicSystem.Models.Playlist> Playlist { get; set; }

        public DbSet<CodeFirstMusicSystem.Models.PlaylistSong> PlaylistSong { get; set; }

        public DbSet<CodeFirstMusicSystem.Models.Song> Song { get; set; }

        public DbSet<CodeFirstMusicSystem.Models.SongContributor> SongContributor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongContributor>()
                .HasKey(sc => new { sc.ArtistId, sc.SongId });

            modelBuilder.Entity<SongContributor>()
                .HasOne(sc => sc.Artist)
                .WithMany(a => a.SongContributors)
                .HasForeignKey(sc => sc.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongContributor>()
                .HasOne(sc => sc.Song)
                .WithMany(s => s.SongContributors)
                .HasForeignKey(sc => sc.SongId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
