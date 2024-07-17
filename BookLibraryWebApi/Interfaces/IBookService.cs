using BookLibraryWebApi.Dto;
using BookLibraryWebApi.Model;

namespace BookLibraryWebApi.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBook(int bookID);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<bool> CreateBookAsync(BookCreateDto book);
        Task<bool> CreateBookAsync(Book book);
        Task<bool> UpdatBookAsync(Book book);
        Task<bool> DeleteBookAsync(Book book);
    }
}
