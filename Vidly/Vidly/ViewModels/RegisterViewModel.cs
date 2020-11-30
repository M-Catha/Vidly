using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Driver's License")]
        public string DriversLicense { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}