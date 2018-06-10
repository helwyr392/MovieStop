using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStop.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public int GenreID { get; set; }

        public GenreDto Genre { get; set; }

        [Range(1, 999)]
        public int NumberInStock { get; set; }

        [Range(1, 999)]
        public int NumberAvailable { get; set; }
    }
}