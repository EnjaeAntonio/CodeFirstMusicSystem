namespace CodeFirstMusicSystem.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

    }
}
