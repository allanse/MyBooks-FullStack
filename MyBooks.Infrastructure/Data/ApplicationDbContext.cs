using Microsoft.EntityFrameworkCore;
using MyBooks.Domain.Entities; 

namespace MyBooks.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Genre>()
                .HasIndex(g => g.Name)
                .IsUnique();
            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)        
                .WithMany(g => g.Books)      
                .HasForeignKey(b => b.GenreId); 

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)       
                .WithMany(a => a.Books)      
                .HasForeignKey(b => b.AuthorId); 
        }
    }
}