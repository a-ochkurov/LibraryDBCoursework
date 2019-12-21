using BookLibrary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var authors = _authorService.Get();

            return View(authors);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorService.Get(id.Value);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }


    }
}