using LibreriaColibri.Data;
using LibreriaColibri.Models;
using LibreriaColibri.Models.Dtos;
using LibreriaColibri.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibreriaColibri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryContext _context;

        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.BooksMostBuyers = _context.GetBooks.FromSqlRaw($"sp_BestSellers");
            model.BooksLastAdded = _context.GetBooks.FromSqlRaw($"sp_LastAdded");
            return View("Home",model);
        }

        public IActionResult Privacy()
        {

            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
        
    
    
    
    
    
    }
}