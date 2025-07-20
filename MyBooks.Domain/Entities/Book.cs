namespace MyBooks.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; } = null!; 
        public Author Author { get; set; } = null!;
    }
}