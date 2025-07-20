// MyBooks.Application/Interfaces/IBookService.cs
using MyBooks.Application.DTOs;

namespace MyBooks.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllAsync();
        Task<BookResponse?> GetByIdAsync(int id);
        Task<BookResponse> CreateAsync(BookCreateRequest createRequest);
        Task<BookResponse?> UpdateAsync(int id, BookUpdateRequest updateRequest);
        Task<bool> DeleteAsync(int id);
    }
}