using Microsoft.EntityFrameworkCore;

namespace LibreriaColibri.Models.Dtos
{
    [Keyless]
    public class GetTOrderBooksDto
    {
        public int IdOrder { set; get; }
        public int IdBook { set; get; }
        public int Quantity { set; get; }

    }
}
