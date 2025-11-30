using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EFCore;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _manager.Book.GetAllBooks(trackChanges: false).ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager.Book.GetBookById(id, trackChanges: false);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                _manager.Book.Create(book);
                _manager.Save();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book updatedBook)
        {
            try
            {
                var book = _manager.Book.GetBookById(id, trackChanges: true);
                if (book == null)
                {
                    return NotFound();
                }
                if (id != updatedBook.Id)
                {
                    return BadRequest();
                }
                book.Title = updatedBook.Title;
                book.Price = updatedBook.Price;
                _manager.Save();
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager.Book.GetBookById(id, trackChanges: false);
                if (book == null)
                {
                    return NotFound();
                }
                _manager.Book.Delete(book);
                _manager.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> patchedBook)
        {
            try
            {
                var book = _manager.Book.GetBookById(id, trackChanges: true);
                if (book == null)
                {
                    return NotFound();
                }
                patchedBook.ApplyTo(book);
                _manager.Book.Update(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
