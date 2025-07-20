// MyBooks.Infrastructure/Data/UnitOfWork.cs
using MyBooks.Domain.Entities;
using MyBooks.Domain.Interfaces;
using MyBooks.Infrastructure.Data.Repositories;

namespace MyBooks.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Genre> Genres { get; private set; }
        public IGenericRepository<Author> Authors { get; private set; }
        public IBookRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Genres = new GenericRepository<Genre>(_context);
            Authors = new GenericRepository<Author>(_context);
            Books = new BookRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}