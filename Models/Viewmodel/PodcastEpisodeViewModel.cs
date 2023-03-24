namespace CodeFirstMusicSystem.Models.Viewmodel
{
    public class PodcastEpisodeViewModel
    {
        public int SelectedEpisodeId { get; set; }
        public Podcast Podcast { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}
