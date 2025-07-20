using MyBooks.Api.DTOs;

namespace MyBooks.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponse>> GetAllAsync();
        Task<GenreResponse?> GetByIdAsync(int id);
        Task<GenreResponse> CreateAsync(GenreCreateRequest createRequest);
        Task<GenreResponse?> UpdateAsync(int id, GenreUpdateRequest updateRequest);
        Task<bool> DeleteAsync(int id);
    }
}