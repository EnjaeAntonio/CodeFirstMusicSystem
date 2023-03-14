namespace CodeFirstMusicSystem.Models
{
    public class SongContributor
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
        public int ArtistId { get; set; }
        public int SongId { get; set; }

        public SongContributor()
        {
        }

        public SongContributor(int artistId, int songId)
        {
            ArtistId = artistId;
            SongId = songId;
        }
    }

}
