using System.ComponentModel.DataAnnotations;

namespace CodeFirstMusicSystem.Models.Viewmodel
{
    public class CreateSongViewModel
    {
        public Song Song { get; set; }
        [Required(ErrorMessage = "Artist is required.")]
        [Display(Name ="Artist")]
        public int ArtistId { get; set; }

        public CreateSongViewModel()
        {
            Song = new Song();
        }
    }
}
