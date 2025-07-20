using MyBooks.Application.DTOs;

namespace MyBooks.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponse>> GetAllAsync();
        Task<AuthorResponse?> GetByIdAsync(int id);
        Task<AuthorResponse> CreateAsync(AuthorCreateRequest createRequest);
        Task<AuthorResponse?> UpdateAsync(int id, AuthorUpdateRequest updateRequest);
        Task<bool> DeleteAsync(int id);
    }
}