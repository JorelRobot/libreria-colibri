

using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaColibri.Models.Dtos
{
    public class GetOrderDto
    {
        //[Required] se utiliza solamente cuando el usuario interactua con los datos
        //modelo tipo orden
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status{ get; set; }
        public string IdUser { get; set; }

        [NotMapped]
        public IEnumerable<GetOrderBooksDto>? BooksInOrders { get; set; }
    }
}
