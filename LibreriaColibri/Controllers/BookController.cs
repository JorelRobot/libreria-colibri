using LibreriaColibri.Data;
using LibreriaColibri.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaColibri.Controllers
{
    public class BookController : Controller
    {
        private LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookSearchResults(string search)
        {
            SearchViewModel model = new SearchViewModel();
            if (search == null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                model.SearchText = search;
                model.SearchBooks = _context.GetBooks.FromSqlRaw($"sp_SelectBookByTitle {search}").ToList();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult BookDetails()
        {
            return View();
        }
    }
}
