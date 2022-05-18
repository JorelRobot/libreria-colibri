namespace LibreriaColibri.Models.Dtos
{
    public class GetOrderBooksDto
    {
        //modelo tipo libro
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Img { get; set; }
        public int Quantity { get; set; }
        public int IdBook { get; set; }

    }
}
