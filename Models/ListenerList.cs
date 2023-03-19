namespace CodeFirstMusicSystem.Models
{
    public class ListenerList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Podcast> Podcasts { get; set; } = new HashSet<Podcast>();
    }
}
