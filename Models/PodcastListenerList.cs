namespace CodeFirstMusicSystem.Models
{
    public class PodcastListenerList
    {
        public int Id { get; set; }
        public int ListenerListId { get; set; }
        public ListenerList ListenerList { get; set; }

        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }

        public PodcastListenerList() { }
        public PodcastListenerList(int podcastId, int listenerListId)
        {
            PodcastId = podcastId;
            ListenerListId = listenerListId;
        }
    }
}
