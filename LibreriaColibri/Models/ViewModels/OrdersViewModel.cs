using LibreriaColibri.Models.Dtos;

namespace LibreriaColibri.Models.ViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<GetOrderDto> Orders { get; set; }
        //public  IEnumerable<GetOrderBooksDto> BooksInOrders { get; set; }
    }
}


/*creamos un modelo con otros modelos dentro, cada uno con un alias que usaremos en el controlador 
  
 */