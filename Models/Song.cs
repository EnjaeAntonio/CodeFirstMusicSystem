using System.ComponentModel.DataAnnotations;

namespace CodeFirstMusicSystem.Models
{

    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DurationSeconds { get; set; }
    }
    public class Song : Media
    {
     
        public Album Album { get; set; }

        public int AlbumId { get; set; }
    }

    public class Episode : Media
    {
        [DataType(DataType.Date)]

        public DateTime AirDate { get; set; }
    }
}
