using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cart() 
        { 
            return View(); 
        }
    }
}
