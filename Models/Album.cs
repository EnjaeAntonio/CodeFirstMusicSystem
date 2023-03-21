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

        public ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<PodcastCastArtist> PodcastCastArtists { get; set; }

        public virtual ICollection<PodcastListenerList> PodcastListenerLists { get; set; }
        public Podcast(string title, DateTime releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
        }
    }
}
