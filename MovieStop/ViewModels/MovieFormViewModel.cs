using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieStop.Models;

namespace MovieStop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreID { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 999)]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number Available")]
        [Range(1, 999)]
        public int? NumberAvailable { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            NumberAvailable = movie.NumberAvailable;
            GenreID = movie.GenreID;
        }
    }
}