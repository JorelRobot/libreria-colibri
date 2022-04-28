using System.ComponentModel.DataAnnotations;

namespace LibreriaColibri.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfrimPassword { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        

    }
}
