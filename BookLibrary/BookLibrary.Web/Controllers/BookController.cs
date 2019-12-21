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
        public IActionResult Index()
        {
            var books = _bookService.Get();

            if (books != null)
            {
                return Ok(books);
            }

            return NotFound();
        }
    }
}