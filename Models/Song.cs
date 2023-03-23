namespace CodeFirstMusicSystem.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public int TrackNumber { get; set; }
        public virtual Album Album { get; set; }
        public int AlbumId { get; set; }
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
