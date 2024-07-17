using BookLibraryWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
