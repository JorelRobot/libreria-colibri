using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibreriaColibri.Data;
using Microsoft.AspNetCore.Authorization;

namespace LibreriaColibri.Controllers
{
    [Authorize(Roles="Administrador")]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LibraryContext _context;
        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, LibraryContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(IdentityRole rol)
        {
            if (await _roleManager.RoleExistsAsync(rol.Name))
            {
                TempData["Error"] = "El rol ya existe";
                return RedirectToAction(nameof(Index));
            }
            //crear el rol
            await _roleManager.CreateAsync(new IdentityRole() { Name = rol.Name });
            TempData["Correcto"] = "Rol creado";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                //actualizar rol
                var rolBD = _context.Roles.FirstOrDefault(r => r.Id == id);
                return View(rolBD);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(IdentityRole rol)
        {
            if (await _roleManager.RoleExistsAsync(rol.Name))
            {
                TempData["Error"] = "El rol ya existe";
                return RedirectToAction(nameof(Index));
            }
            //crear el rol

            var rolBD = _context.Roles.FirstOrDefault(r => r.Id == rol.Id);
            if (rolBD == null)
            {
                return RedirectToAction(nameof(Index));
            }

            rolBD.Name=rol.Name;
            rolBD.NormalizedName = rol.Name.ToUpper();
            var resultado=await _roleManager.UpdateAsync(rolBD);
            TempData["Correcto"] = "Rol modificado";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrar(string id)
        {
            var rolBD = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (rolBD == null)
            {
                TempData["Error"] = "No existe";
                return RedirectToAction(nameof(Index));
            }
            var usuarioConRol = _context.UserRoles.Where(u => u.RoleId == id).Count();
            if (usuarioConRol > 0)
            {
                TempData["Error"] = "El rol tiene usuarios, no se puede borrar";
                return RedirectToAction(nameof(Index));
            }

            await _roleManager.DeleteAsync(rolBD);
            TempData["Correcto"] = "El rol ha sido eliminado";
            return RedirectToAction(nameof(Index));
        }
    }
}
