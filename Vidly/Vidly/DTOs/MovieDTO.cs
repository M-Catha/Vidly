using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public DateTime? DateAdded { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}