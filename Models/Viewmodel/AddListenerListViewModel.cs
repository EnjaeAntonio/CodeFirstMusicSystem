namespace CodeFirstMusicSystem.Models.Viewmodel
{
    public class AddListenerListViewModel
    {
        public int Id { get; set; }
        public List<Podcast> Podcasts { get; set; }
        public List<ListenerList> ListenerLists { get; set; }
        public int PodcastId { get; set; }
        public int ListenerListId { get; set; }
    }
}
