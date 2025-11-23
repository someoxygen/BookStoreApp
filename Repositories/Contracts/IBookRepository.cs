using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        IQueryable<Book> GetAllBooks(bool trackChanges);
        IQueryable<Book> GetBookById(int bookId, bool trackChanges);
    }
}
