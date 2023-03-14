namespace CodeFirstMusicSystem.Models.Viewmodel
{
   public class AddSongViewModel
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Song> Songs { get; set; }
    }

}
