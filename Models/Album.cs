using System.ComponentModel.DataAnnotations;

namespace CodeFirstMusicSystem.Models
{
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
}
