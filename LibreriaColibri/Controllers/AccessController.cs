using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
