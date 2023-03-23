using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeFirstMusicSystem.Models
{
    public abstract class Media
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 50 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

  
    }

    public class Song : Media
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Album is required.")]
        public virtual Album Album { get; set; }

        [Required(ErrorMessage = "Album ID is required.")]
        public int AlbumId { get; set; }

        public int TrackSong { get; set; }
        public virtual ICollection<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        // podcasts artists M to M
        // podcast to L.L M to M
        [Required(ErrorMessage = "Duration is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Duration must be a positive value.")]
        [Display(Name = "Duration Seconds")]
        public int DurationSeconds { get; set; }

        public Song()
        {
        }

        public Song(int trackSong, string title, int durationSeconds, int albumId)
        {
            TrackSong = trackSong;
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
        }
    }
    public class Episode : Media
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Date Aired")]
        public DateTime AirDate { get; set; }
        
        public virtual Podcast Podcast { get; set; }
        public int PodcastId { get; set; }
        public ICollection<GuestArtistEpisode> GuestArtistEpisodes { get; set; } = new HashSet<GuestArtistEpisode>();
        public Episode()
        {
        }

        public Episode(string title, DateTime airDate)
        {
            Title = title;
            AirDate = airDate;
        }
    }
}
