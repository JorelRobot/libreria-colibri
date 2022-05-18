using LibreriaColibri.Data;
using LibreriaColibri.Models.Dtos;
using LibreriaColibri.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaColibri.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly LibraryContext _context;
        
        public OrderController(UserManager<IdentityUser> userManager, LibraryContext context)
        {
            this._userManager = userManager;
            this._context=context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult OrderDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cart() 
        { 
            return View(); 
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var id = _userManager.GetUserId(User);
            

           
            var orders = _context.GetOrderDto.FromSqlRaw($"sp_SelectOrdersByUser '{id}'").ToList();
            //var books = _context.GetOrderBooks.FromSqlRaw($"sp_SelectBooksFromOrder '{}'").ToList();
            var orderBooks = _context.GetTOrderBooks.FromSqlRaw($"sp_SelectOrderBook").ToList();
            GetOrderBooksDto[] arreglo;// = new GetOrderBooksDto[books.Count()];


            //for (int i = 0; i < books.Count(); i++)
            //{
            //    arreglo[i] = books.ElementAt(i);
            //}

            foreach (var order in orders) {
                
                if (order == null)
                {
                    return NotFound();
                }
                else
                {
                    var books = _context.GetOrderBooks.FromSqlRaw($"sp_SelectBooksFromOrder '{order.Id}'").ToList();
                    arreglo = new GetOrderBooksDto[books.Count()];
                    for (int i = 0; i < books.Count(); i++)
                    {
                        arreglo[i] = books.ElementAt(i);
                    }
                    order.BooksInOrders = arreglo; 

                }
            
            
            }

                return View(orders);
        }


    }
}
