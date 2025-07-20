using System.ComponentModel.DataAnnotations;

namespace MyBooks.Api.DTOs
{
    public class GenreCreateRequest
    {
        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do gênero não pode exceder 100 caracteres.")]
        public string Name { get; set; } = string.Empty;        
    }

    public class GenreUpdateRequest : GenreCreateRequest
    {
        [Required(ErrorMessage = "O ID do gênero é obrigatório.")]
        public int Id { get; set; }        
    }

    public class GenreResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;        
    }
}