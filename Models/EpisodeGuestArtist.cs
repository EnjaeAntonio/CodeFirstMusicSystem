namespace CodeFirstMusicSystem.Models
{
    public class EpisodeGuestArtist
    {
        public int Id { get; set; }

        public Episode Episode { get; set; }

        public int EpisodeId { get; set; }


    }
}
