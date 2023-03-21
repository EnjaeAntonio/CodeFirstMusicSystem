﻿namespace CodeFirstMusicSystem.Models
{

    public class BaseArtist 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Artist : BaseArtist
    {
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

    public class GuestArtist : BaseArtist
    {
        public ICollection<EpisodeGuestArtist> EpisodeGuestArtists { get; set; }

        public GuestArtist(string name)
        {
            Name = name;
        }
    }

    public class PodcastArtist : BaseArtist
    {
        public ICollection<PodcastCastArtist> PodcastCastArtists { get; set; }

        public PodcastArtist(string name)
        {
            Name = name;
        }
    }
}
