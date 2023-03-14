namespace CodeFirstMusicSystem.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();

        public Artist()
        {
        }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
