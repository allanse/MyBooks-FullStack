using Microsoft.EntityFrameworkCore;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Interfaces;

namespace MyBooks.Infrastructure.Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}