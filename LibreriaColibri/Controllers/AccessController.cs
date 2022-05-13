using LibreriaColibri.Data;
using LibreriaColibri.Models;
using LibreriaColibri.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibreriaColibri.Controllers
{
    public class AccessController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //yo le movi
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LibraryContext _context;
        //yo le movi

        //puse en el constructor lo de arriba
        public AccessController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, LibraryContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //hola soy yo
            _roleManager = roleManager;
            _context = context;
            //mejor no
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = model.Email, Email = model.Email, Name = model.Name, PhoneNumber = model.Phone, 
                                         Address = model.Address, ZipCode = model.ZipCode, City = model.City, Country = model.Country
                                         };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //meti mi mano en el codigo tiemblen
                    //asignar usuario a un rol por defecto cliente
                    await _userManager.AddToRoleAsync(user, "Cliente");
                    //si tu lo deseas puedes volar
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                ValidateErrors(result);
            }
            return View(model);
        }

        private void ValidateErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El correo o la contraseña son incorrectos");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Access");
        }



        //////////////////////
        //registro especial del administrador
        
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult SignupAdmin()
        {
            //para seleccionar rol
            List<SelectListItem> RolesList=new List<SelectListItem>();
            var roles = _context.Roles;
            foreach (var rol in roles)
            {
                RolesList.Add(new SelectListItem()
                {
                    Value = rol.Name,
                    Text = rol.Name
                });
            }
            SignupViewModel model = new SignupViewModel()
            {
                RolesList = RolesList
            };
            //para seleccionar rol
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> SignupAdmin(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.Phone,
                    Address = model.Address,
                    ZipCode = model.ZipCode,
                    City = model.City,
                    Country = model.Country
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //meti mi mano en el codigo tiemblen
                    //asignar usuario a un rol
                    if (model.SelectedRol != null && model.SelectedRol.Length > 0 && model.SelectedRol == "Administrador")
                    {
                        await _userManager.AddToRoleAsync(user, "Administrador"); 
                    }
                    else if (model.SelectedRol != null && model.SelectedRol.Length > 0 && model.SelectedRol == "Empleado")
                    {
                        await _userManager.AddToRoleAsync(user, "Empleado");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Cliente");
                    }
                    //si tu lo deseas puedes volar
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                ValidateErrors(result);
            }


            //para seleccionar rol
            List<SelectListItem> RolesList = new List<SelectListItem>();
            var roles = _context.Roles;
            foreach (var rol in roles)
            {
                RolesList.Add(new SelectListItem()
                {
                    Value = rol.Name,
                    Text = rol.Name
                });
            }
            //para seleccionar rol

            model.RolesList= RolesList;


            return View(model);
        }


    }
}
