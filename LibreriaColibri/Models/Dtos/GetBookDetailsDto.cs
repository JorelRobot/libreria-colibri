namespace LibreriaColibri.Models.Dtos
{
    public class GetBookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Ph { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Depot { get; set; }
        public string? Img { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }

    }
}
