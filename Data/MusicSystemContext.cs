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

        public DbSet<CodeFirstMusicSystem.Models.Episode>? Episode { get; set; }

        public DbSet<CodeFirstMusicSystem.Models.ListenerList>? ListenerList { get; set; }

        public DbSet<CodeFirstMusicSystem.Models.Podcast>? Podcast { get; set; }
        

        public void ModelCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasDiscriminator<string>("Type")
                .HasValue<Song>("Song")
                .HasValue<Episode>("Episode");

            modelBuilder.Entity<Episode>()
                .HasBaseType<Song>()
                .HasDiscriminator<string>("Type")
                .HasValue("Episode");

        }

    }
}
