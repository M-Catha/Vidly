using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        [DisplayName("Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public int Id { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [DisplayName("Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}