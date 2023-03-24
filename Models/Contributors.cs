using System.ComponentModel.DataAnnotations;


namespace CodeFirstMusicSystem.Models
{
    public class Contributors
    {
        public int Id { get; set; }
    }

    public class SongContributor : Contributors
    {
        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
        [Required(ErrorMessage = "Artist is required.")]
        public int ArtistId { get; set; }
        public int SongId { get; set; }

        public SongContributor()
        {
        }

        public SongContributor(int artistId, int songId)
        {
            ArtistId = artistId;
            SongId = songId;
        }
    }

    public class PlaylistSong : Contributors
    {
        public virtual Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public virtual Song Song { get; set; }
        public int SongId { get; set; }

        public PlaylistSong() { }
        public PlaylistSong(int songId, int playlistId)
        {
            PlaylistId = playlistId;
            SongId = songId;
        }
    }



    public class PodcastListenerList : Contributors
    {
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

    public class PodcastCastArtist : Contributors
    {
        public int PodcastArtistId { get; set; }
        public PodcastArtist PodcastArtist { get; set; }

        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public PodcastCastArtist(int podcastId, int podcastArtistId)
        {
            PodcastId = podcastId;
            PodcastArtistId = podcastArtistId;
        }
    }

    public class GuestArtistEpisode : Contributors
    {
        public int GuestArtistId { get; set; }
        public GuestArtist GuestArtist { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public GuestArtistEpisode(int episodeId, int guestArtistId)
        {
            EpisodeId = episodeId;
            GuestArtistId = guestArtistId;
        }
    }
}
