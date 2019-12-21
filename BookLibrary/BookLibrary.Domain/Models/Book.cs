namespace BookLibrary.Domain.Models
{
    public class Book : BaseModel
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public int Quantity { get; set; }

        public int Pages { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }
    }
}
