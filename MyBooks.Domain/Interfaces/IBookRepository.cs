using MyBooks.Domain.Entities;

namespace MyBooks.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Book>> GetAllWithDetailsAsync();
    }
}