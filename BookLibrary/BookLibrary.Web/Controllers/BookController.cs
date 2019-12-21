using BookLibrary.BLL.Interfaces;
using BookLibrary.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult AllBooks()
        {
            var books = _bookService.Get();

            if (books != null)
            {
                return Ok(books);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            var book = _bookService.Get(id);

            if (book != null)
            {
                return new ObjectResult(book);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book != null)
            {
                _bookService.Add(book);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (book != null)
            {
                book.BookId = id;
                _bookService.Update(book);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _bookService.Remove(id);
                return Ok();
            }

            return BadRequest();
        }
    }
}