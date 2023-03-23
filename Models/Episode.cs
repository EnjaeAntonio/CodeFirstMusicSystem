namespace CodeFirstMusicSystem.Models
{
    public class Episode : Song
    {
        public DateTime AirDate { get; set; }
        public virtual ICollection<Artist> GuestArtists { get; set; } = new HashSet<Artist>();

    }
}
