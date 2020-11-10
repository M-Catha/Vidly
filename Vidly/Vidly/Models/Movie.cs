using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public DateTime? DateAdded { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [DisplayName("Genre")]
        public byte GenreId { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [DisplayName("Number in Stock")]
        public byte NumberInStock { get; set; }

        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }
    }
}