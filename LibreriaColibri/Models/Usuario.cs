using Microsoft.AspNetCore.Identity;

namespace LibreriaColibri.Models
{
    public class Usuario : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
