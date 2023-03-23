namespace CodeFirstMusicSystem.Models
{
    public class GuestArtistEpisode
    {
        public int Id { get; set; }
        public int GuestArtistId { get; set; }
        public GuestArtist GuestArtist { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public GuestArtistEpisode(int episodeId, int guestArtistId) 
        {
            EpisodeId = episodeId;
            GuestArtistId = guestArtistId;
        }
    }
}
