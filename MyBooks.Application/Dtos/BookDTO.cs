// MyBooks.Application/DTOs/BookDto.cs
using MyBooks.Api.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Application.DTOs
{
    public class BookCreateRequest
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }

    public class BookUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }

    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
        public AuthorResponse? Author { get; set; }
        public GenreResponse? Genre { get; set; }
    }
}