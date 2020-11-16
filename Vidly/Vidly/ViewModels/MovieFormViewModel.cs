using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            GenreId = movie.GenreId;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate
        }

        [Required]
        [DisplayName("Genre")]
        public byte? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        public Movie Movie { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, 20)]
        [DisplayName("Number in Stock")]
        public byte? NumberInStock { get; set; }

        [Required]
        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}