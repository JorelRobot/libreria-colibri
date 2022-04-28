using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] IActionResult OrderDetails()
        {
            return View();
        }

        [HttpGet]
        IActionResult OrderError()
        {
            return View();
        }
    }
}
