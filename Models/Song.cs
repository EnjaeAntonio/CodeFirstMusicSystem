using System.ComponentModel.DataAnnotations;

namespace CodeFirstMusicSystem.Models
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title must be between 1 and 100 characters.", MinimumLength = 1)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive number.")]
        public int DurationSeconds { get; set; }

        [Required(ErrorMessage = "Album is required.")]
        public virtual Album Album { get; set; }
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Artist is required.")]
        public virtual ICollection<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        public Song()
        {
        }

        public Song(string title, int durationSeconds, int albumId, int trackNumber)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
            TrackNumber = trackNumber;
        }
    }

}
