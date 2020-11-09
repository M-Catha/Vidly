using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public DateTime? Birthdate { get; set; }

        public int Id { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}