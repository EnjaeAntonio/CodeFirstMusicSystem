namespace CodeFirstMusicSystem.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();

        public Album()
        {
        }

        public Album(string title, DateTime releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
        }
    }
}
