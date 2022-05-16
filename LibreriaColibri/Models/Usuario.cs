using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaColibri.Models
{
    public class Usuario : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //PUSE ESTE haber si jala
        //[Required]
        //public string Phone { get; set; }

        //cosas para el crud de usuarios
        //[NotMapped]
        //public string Phone { get; set; }
        [NotMapped]
        [Display(Name="Rol para el usuario")]
        public string IdRol { get; set; }
        [NotMapped]
        public string Rol { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? ListaRoles{ get; set; }
    }
}
