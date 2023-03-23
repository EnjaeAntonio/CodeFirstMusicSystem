namespace CodeFirstMusicSystem.Models
{

    public class MediaCollection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public HashSet<Song> Songs { get; set; }
    }
    public class Album : MediaCollection
    {
      
    }

    public class Podcast : MediaCollection
    {
        // Collection of artissts
    }
}
