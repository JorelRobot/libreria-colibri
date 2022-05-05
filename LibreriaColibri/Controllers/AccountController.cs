using LibreriaColibri.Data;
using LibreriaColibri.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly LibraryContext _context;
        
        public AccountController(UserManager<IdentityUser> userManager, LibraryContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            ProfileViewModel model = new ProfileViewModel();
            var id =  _userManager.GetUserId(User);
            if (id == null)
            {
                NotFound();
            }
            var currentUser = await _context.Usuario.FindAsync(id);
            if(currentUser == null)
            {
                NotFound();
            }
            model.Id = currentUser.Id;
            model.City = currentUser.City;
            model.Address = currentUser.Address;
            model.Phone = currentUser.PhoneNumber;
            model.ZipCode = currentUser.ZipCode;
            model.Country = currentUser.Country;
            model.Name = currentUser.Name;
            model.Email = currentUser.Email;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MyProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _context.Usuario.FindAsync(model.Id);

                currentUser.Id = model.Id;
                currentUser.City = model.City;
                currentUser.Address = model.Address;
                currentUser.PhoneNumber = model.Phone;
                currentUser.ZipCode = model.ZipCode;
                currentUser.Country = model.Country;
                currentUser.Name = model.Name;
                currentUser.Email = model.Email;

                await _userManager.UpdateAsync(currentUser);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
