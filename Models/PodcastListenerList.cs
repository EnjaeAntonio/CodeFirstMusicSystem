namespace CodeFirstMusicSystem.Models
{
    public class PodcastListenerList
    {
        public int Id { get; set; }
        public virtual ListenerList ListenerList { get; set; }
        public int ListenerListId { get; set; }
        public virtual Podcast Podcast { get; set; }
        public int PodcastId { get; set; }

        public PodcastListenerList(int listenerListId, int podcastId)
        {
            ListenerListId = listenerListId;
            PodcastId = podcastId;
        }
    }
}
