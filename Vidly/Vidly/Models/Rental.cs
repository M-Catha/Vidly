using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        [Required]
        public Customer Customer { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }
    }
}