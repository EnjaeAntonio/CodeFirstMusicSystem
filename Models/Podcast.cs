namespace CodeFirstMusicSystem.Models
{
    public class Podcast : MediaCollection
    {
        public int Id { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
