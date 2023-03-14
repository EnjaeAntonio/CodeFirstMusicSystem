namespace CodeFirstMusicSystem.Models.Viewmodel
{
    public class PlaylistDetailsViewModel
    {
        public Playlist Playlist { get; set; }
        public ICollection<Song> Songs { get; set; }
        public int TotalRuntime { get; set; }
        public int SongCount { get; set; }
    }
}
