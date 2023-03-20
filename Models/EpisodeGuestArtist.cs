namespace CodeFirstMusicSystem.Models
{
    public class EpisodeGuestArtist
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int GuestArtistId { get; set; }
        public Artist GuestArtist { get; set; }
    }
}
