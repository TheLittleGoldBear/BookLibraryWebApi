using BookLibraryWebApi.Model;

namespace BookLibraryWebApi.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> BookExists(int bookID);
        Task<Book> GetBook(int bookID);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<bool> CreateBookAsync(Book book);
        Task<bool> UpdatBookAsync(Book book);
        Task<bool> DeleteBookAsync(Book book);
        Task<bool> Saved();
    }
}
