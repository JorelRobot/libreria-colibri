using System.ComponentModel.DataAnnotations;

namespace LibreriaColibri.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required (ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Check me out")]
        public bool RememberMe { get; set; }
    }
}
