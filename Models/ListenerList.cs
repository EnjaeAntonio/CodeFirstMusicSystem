namespace CodeFirstMusicSystem.Models
{
    public class ListenerList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PodcastListenerList> ListenerListPodcasts { get; set; } = new HashSet<PodcastListenerList>();

        public ListenerList(string name)
        {
            Name = name;
        }
    }
}