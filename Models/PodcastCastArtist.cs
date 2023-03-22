namespace CodeFirstMusicSystem.Models
{
    public class PodcastCastArtist
    {
        public int Id { get; set; }
        public int PodcastArtistId { get; set; }
        public PodcastArtist PodcastArtist { get; set; }

        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
    }
}
