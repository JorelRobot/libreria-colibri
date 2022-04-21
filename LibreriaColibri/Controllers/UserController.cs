using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
