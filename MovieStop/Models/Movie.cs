using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleasedDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }

        [Required]
        [Range(1, 999)]
        public int NumberInStock { get; set; }

        [Required]
        [Range(1, 999)]
        public int NumberAvailable { get; set; }
    }
}