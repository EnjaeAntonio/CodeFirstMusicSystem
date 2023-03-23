using System.ComponentModel.DataAnnotations;

namespace CodeFirstMusicSystem.Models
{

    public class MediaCollection
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 50 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]

        public DateTime ReleaseDate { get; set; }
    }

    public class Album : MediaCollection
    {
        public int Id { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
        public Album()
        {
        }

        public Album(string title, DateTime releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
        }
    }

    public class Podcast : MediaCollection
    {
        public int Id { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();
        public ICollection<PodcastCastArtist> PodcastCastArtists { get; set; } = new HashSet<PodcastCastArtist>();
        public ICollection<PodcastListenerList> PodcastListenerLists { get; set; } = new HashSet<PodcastListenerList>();
        public Podcast(string title, DateTime releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
        }
    }
}
