namespace CodeFirstMusicSystem.Models.Viewmodel
{
    public class AlbumArtistViewModel
    {
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Album> AlbumsByArtist { get; set; }
    }
}
