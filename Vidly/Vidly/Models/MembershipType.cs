using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte DiscountRate { get; set; }

        public byte DurationInMonths { get; set; }

        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYoGo = 1;
    }
}