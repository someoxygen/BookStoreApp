using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);

        public IQueryable<Book> GetAllBooks(bool trackChanges) 
            => FindAll(trackChanges);

        public Book GetBookById(int bookId, bool trackChanges) 
            => FindByCondition(book => book.Id == bookId, trackChanges).SingleOrDefault();

        public void UpdateBook(Book book) => Update(book);
    }
}
