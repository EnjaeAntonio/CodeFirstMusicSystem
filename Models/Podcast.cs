namespace CodeFirstMusicSystem.Models
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();

        public virtual ICollection<Artist> CastArtists { get; set; } = new HashSet<Artist>();

        public virtual ICollection<ListenerList> ListenerList { get; set; } = new HashSet<ListenerList>();
    }
}
