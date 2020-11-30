using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Driver's License")]
        public string DriversLicense { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}