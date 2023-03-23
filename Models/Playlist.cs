using System.ComponentModel.DataAnnotations;

namespace CodeFirstMusicSystem.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters.")]
        public string Name { get; set; }

        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

    }
}
