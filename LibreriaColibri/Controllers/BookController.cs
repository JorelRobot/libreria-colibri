using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class BookController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
