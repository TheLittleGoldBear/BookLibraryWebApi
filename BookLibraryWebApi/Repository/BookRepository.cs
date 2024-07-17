using BookLibraryWebApi.Data;
using BookLibraryWebApi.Interfaces;
using BookLibraryWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebApi.Repository
{
    public class BookRepository(ApplicationDbContext context) : IBookRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<bool> BookExists(int bookId)
        {
            return _context.Books.AnyAsync(x => x.BookId == bookId);
        }

        public async Task<Book> GetBook(int bookID)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.BookId == bookID);
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<bool> CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            return await Saved();
        }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            return await Saved();
        }

        public async Task<bool> UpdatBookAsync(Book book)
        {
            _context.Books.Update(book);
            return await Saved();
        }

        public async Task<bool> Saved()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
