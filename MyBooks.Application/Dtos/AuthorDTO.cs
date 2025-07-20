using System.ComponentModel.DataAnnotations;

namespace MyBooks.Application.DTOs
{
    public class AuthorCreateRequest
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }
    }

    public class AuthorUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }
    }

    public class AuthorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Nationality { get; set; }
    }
}