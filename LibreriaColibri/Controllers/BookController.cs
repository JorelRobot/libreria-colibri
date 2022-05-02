using LibreriaColibri.Data;
using LibreriaColibri.Models.Dtos;
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
        public IActionResult BookDetails(int id)
        {
            IEnumerable<GetBookDetailsDto> getBookDetails = _context.GetBookDetails.FromSqlRaw($"sp_SelectBookById {id}").ToList();
            GetBookDetailsDto model;
            if(getBookDetails == null)
            {
                return NotFound();
            }
            else
            {
                model = getBookDetails.First();
            }
            return View(model);
        }
    }
}
