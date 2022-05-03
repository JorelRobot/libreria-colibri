using LibreriaColibri.Models.Dtos;

namespace LibreriaColibri.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<GetBooksDto> BooksMostBuyers { get; set; }
        public IEnumerable<GetBooksDto> BooksLastAdded { get; set; }
    }
}
