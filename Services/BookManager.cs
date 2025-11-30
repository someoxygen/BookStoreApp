using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public Book CreateBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _manager.Book.CreateBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteBook(int bookId, bool trackChanges)
        {
            if (bookId <= 0)
            {
                throw new ArgumentNullException(nameof(bookId));
            }
            var book = _manager.Book.GetBookById(bookId, trackChanges);
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _manager.Book.DeleteBook(book);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges).ToList();
        }

        public Book GetBookById(int bookId, bool trackChanges)
        {
            if (bookId <= 0)
            {
                throw new ArgumentNullException(nameof(bookId));
            }
            return _manager.Book.GetBookById(bookId, trackChanges);
        }

        public void UpdateBook(int bookId, Book book, bool trackChanges)
        {
            if (bookId <= 0)
            {
                throw new ArgumentNullException(nameof(bookId));
            }
            var existingBook = _manager.Book.GetBookById(bookId, trackChanges);
            if (existingBook == null)
            {
                throw new ArgumentNullException(nameof(existingBook));
            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;

            _manager.Book.Update(existingBook);
            _manager.Save();
        }
    }
}
