namespace LibreriaColibri.Models.Dtos
{
    public class GetBooksDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string? Img { get; set; }
    }
}
