namespace CodeFirstMusicSystem.Models
{
    public class Episode : Media
    {
        public int Id { get; set; }
        public List<EpisodeGuestArtist> GuestArtists { get; set; }

    }
}
