using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeFirstMusicSystem.Models
{
    public class Song : Media
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Album is required.")]
        public virtual Album Album { get; set; }

        [Required(ErrorMessage = "Album ID is required.")]
        public int AlbumId { get; set; }

        public virtual ICollection<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        // podcasts artists M to M
        // podcast to L.L M to M

        public Song()
        {
        }

        public Song(string title, int durationSeconds, int albumId)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
        }
    }

}
