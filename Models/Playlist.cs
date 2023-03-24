using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeFirstMusicSystem.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Playlist name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Playlist characters must be between 1 and 50 characters.")]
        [Display(Name = "Playlist")]
        public string Name { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        public Playlist(string name)
        {
            Name = name;
        }
    }
}
