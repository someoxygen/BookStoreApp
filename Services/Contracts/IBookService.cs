using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book GetBookById(int bookId, bool trackChanges);
        Book CreateBook(Book book);
        void UpdateBook(int bookId, Book book, bool trackChanges);
        void DeleteBook(int bookId, bool trackChanges);
    }
}
