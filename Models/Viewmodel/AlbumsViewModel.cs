namespace CodeFirstMusicSystem.Models.Viewmodel
{
    public class AlbumsViewModel
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public List<Song> Songs { get; set; }
    }
}
