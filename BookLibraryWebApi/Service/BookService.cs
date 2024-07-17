using AutoMapper;
using BookLibraryWebApi.Dto;
using BookLibraryWebApi.Interfaces;
using BookLibraryWebApi.Model;

namespace BookLibraryWebApi.Service
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Book> GetBook(int bookID)
        {
            var bookExists = await _bookRepository.BookExists(bookID);

            if (!bookExists)
            {
                throw new Exception("Attempt to gt a book which do not exists");
            }

            return await _bookRepository.GetBook(bookID);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetBooksAsync();
        }

        public async Task<bool> CreateBookAsync(BookCreateDto book)
        {
            var mappedBook = _mapper.Map<Book>(book);

            if(mappedBook == null) {
                return false;
            }

            return await CreateBookAsync(mappedBook);
        }

        public async Task<bool> CreateBookAsync(Book book)
        {
            if (book == null)
            {
                return false;
            }

            var bookExists = await _bookRepository.BookExists(book.BookId);

            if (bookExists)
            {
                return false;
            }

            var createdBook = await _bookRepository.CreateBookAsync(book);
            return createdBook;
        }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            if (book == null)
            {
                return false;
            }

            var bookExists = await _bookRepository.BookExists(book.BookId);

            if (bookExists)
            {
                return false;
            }

            var createdBook = await _bookRepository.DeleteBookAsync(book);
            return createdBook;
        }


        public async Task<bool> UpdatBookAsync(Book book)
        {
            if (book == null)
            {
                return false;
            }

            var bookExists = await _bookRepository.BookExists(book.BookId);

            if (bookExists)
            {
                return false;
            }

            var createdBook = await _bookRepository.UpdatBookAsync(book);
            return createdBook;
        }
    }
}
