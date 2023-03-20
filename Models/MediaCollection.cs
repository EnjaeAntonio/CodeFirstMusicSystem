﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeFirstMusicSystem.Models
{
    public class MediaCollection
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 50 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
    }
}