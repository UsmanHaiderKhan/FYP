using System.ComponentModel.DataAnnotations;

namespace FYP.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Register field is required")]
        [Display(Name = "Register-Id")]

        public string RegisterId { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
