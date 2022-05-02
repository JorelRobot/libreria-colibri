using LibreriaColibri.Models.Dtos;

namespace LibreriaColibri.Models.ViewModels
{
    public class SearchViewModel
    {
        public string SearchText { get; set; }
        public IEnumerable<GetBooksDto> SearchBooks { get; set; }
    }
}
