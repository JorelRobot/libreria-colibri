using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaColibri.Models.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        //PUSE ESTO ES OTRA FORMA DE EDITAR USUARIO
        //[Required]
        //public string Phone { get; set; }

        //cosas para el crud de usuarios
        //[NotMapped]
        //[Display(Name = "Rol para el usuario")]
        //public string IdRol { get; set; }
        //[NotMapped]
        //public string Rol { get; set; }
        //[NotMapped]
        //public IEnumerable<SelectListItem>? ListaRoles { get; set; }
    }
}
