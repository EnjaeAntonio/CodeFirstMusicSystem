using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeFirstMusicSystem.Models
{
    public class ListenerList
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public ICollection<PodcastListenerList> ListenerListPodcasts { get; set; } = new HashSet<PodcastListenerList>();

        public ListenerList(string name)
        {
            Name = name;
        }
    }
}