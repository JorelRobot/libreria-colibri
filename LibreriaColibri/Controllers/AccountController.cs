using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
