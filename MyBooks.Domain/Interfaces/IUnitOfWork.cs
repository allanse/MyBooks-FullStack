using MyBooks.Domain.Entities;

namespace MyBooks.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Author> Authors { get; }
        IBookRepository Books { get; }

        Task<int> CompleteAsync();
    }
}