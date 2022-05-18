using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibreriaColibri.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibreriaColibri.Models;
using LibreriaColibri.Models.ViewModels;

namespace LibreriaColibri.Controllers
{
    //le movi a este controlador que estaba vacio Dany no te enojes
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly LibraryContext _context;
        public UserController(UserManager<IdentityUser> userManager, LibraryContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var usuarios = await _context.Usuario.ToListAsync();
            var rolesUsuario = await _context.UserRoles.ToListAsync();
            var roles = await _context.Roles.ToListAsync();

            foreach (var usuario in usuarios)
            {
                var rol = rolesUsuario.FirstOrDefault(u => u.UserId == usuario.Id);
                if(rol == null)
                {
                    usuario.Rol = "Ninguno";
                }
                else
                {
                    usuario.Rol = roles.FirstOrDefault(u => u.Id == rol.RoleId).Name;
                }
            }
            usuarios = usuarios.Where(u => u.Rol != "Cliente").ToList();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            //ProfileViewModel model = new ProfileViewModel();
            ////este es como current user
            //var usrBD= _context.Usuario.FirstOrDefault(u => u.Id == id);
            //if (id == null)
            //{
            //    NotFound();
            //}

            ////trae los rolesUsuario
            //var rolUsuario = _context.UserRoles.ToList();
            ////trae los roles
            //var roles = _context.Roles.ToList();
            ////checa si el usuario tiene un rol
            //var existeRol = rolUsuario.FirstOrDefault(u => u.UserId == usrBD.Id);
            //if (existeRol != null)
            //{
            //    usrBD.IdRol = roles.FirstOrDefault(u => u.Id == existeRol.RoleId).Id;
            //    usrBD.Rol = roles.FirstOrDefault(u => u.Id == existeRol.RoleId).Name;
            //}
            //List<SelectListItem> RolesList = new List<SelectListItem>();
            //foreach (var rol in roles)
            //{
            //    RolesList.Add(new SelectListItem()
            //    {
            //        Value = rol.Id,
            //        Text = rol.Name
            //    });
            //}

            ////usrBD.ListaRoles = RolesList;

            //model.Id = usrBD.Id;
            //model.City = usrBD.City;
            //model.Address = usrBD.Address;
            //model.Phone = usrBD.PhoneNumber;
            //model.ZipCode = usrBD.ZipCode;
            //model.Country = usrBD.Country;
            //model.Name = usrBD.Name;
            //model.Email = usrBD.Email;
            //model.Rol=usrBD.Rol;
            //model.ListaRoles = RolesList;
            //model.IdRol = usrBD.IdRol;

            //return View(model);

            var usuarioBD = _context.Usuario.FirstOrDefault(u => u.Id == id);
            if(usuarioBD == null)
            {
                return NotFound();
            }
            //obtener lista roles-usuarios
            var rolUsuario = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();
            var rolUsr = rolUsuario.FirstOrDefault(u => u.UserId == usuarioBD.Id);
            if (rolUsr != null)
            {
                usuarioBD.IdRol = roles.FirstOrDefault(u => u.Id == rolUsr.RoleId).Id;
                usuarioBD.Rol = roles.FirstOrDefault(u => u.Id == rolUsr.RoleId).Name;
                //usuarioBD.Phone = roles.FirstOrDefault(u => u.Id == rolUsr.RoleId).Name;
            }
            List<SelectListItem> RolesList = new List<SelectListItem>();
            foreach (var rol in roles)
            {
                RolesList.Add(new SelectListItem()
                {
                    Value = rol.Id,
                    Text = rol.Name
                });
            }

            usuarioBD.ListaRoles = RolesList;
            //usuarioBD.ListaRoles = _context.Roles.Select(u => new SelectListItem{
            //    Text = u.Name,
            //    Value = u.Id
            //});
            return View(usuarioBD);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            List<SelectListItem> RolesList = new List<SelectListItem>();
            var roles = _context.Roles.ToList();
            foreach (var rol in roles)
            {
                RolesList.Add(new SelectListItem()
                {
                    Value = rol.Id,
                    Text = rol.Name
                });
            }

            usuario.ListaRoles = RolesList;

            if (ModelState.IsValid)
            {
                var usuarioBD = _context.Usuario.FirstOrDefault(u => u.Id == usuario.Id);
                if (usuarioBD == null)
                {
                    return NotFound();
                }
                var rolUsuario=_context.UserRoles.FirstOrDefault(u => u.UserId == usuarioBD.Id);
                if (rolUsuario != null)
                {
                    //obtener rol actual
                    var rolActual = _context.Roles.Where(r => r.Id == rolUsuario.RoleId).Select(e => e.Name).FirstOrDefault();
                    //eliminar rol actual
                    await _userManager.RemoveFromRoleAsync(usuarioBD, rolActual);
                }

                //agregar rol seleccionado al usuario seleccionado
                await _userManager.AddToRoleAsync(usuarioBD, _context.Roles.FirstOrDefault(u => u.Id == usuario.IdRol).Name);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            //List<SelectListItem> RolesList = new List<SelectListItem>();
            //var roles = _context.Roles.ToList();
            //foreach (var rol in roles)
            //{
            //    RolesList.Add(new SelectListItem()
            //    {
            //        Value = rol.Id,
            //        Text = rol.Name
            //    });
            //}

            //usuario.ListaRoles = RolesList;

            //usuario.ListaRoles = _context.Roles.Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id
            //});

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Borrar(string id)
        {
            var usuarioBD = _context.Usuario.FirstOrDefault(u => u.Id == id);
            if(usuarioBD == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(usuarioBD);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
