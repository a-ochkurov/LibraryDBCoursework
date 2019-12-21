using BookLibrary.BLL.Interfaces;
using BookLibrary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AuthorId,Name,Surname")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Add(author);

                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        public IActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int AuthorId, [Bind("AuthorId,Name,Surname")] Author author)
        {
            if (AuthorId != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.Update(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!authorExists(author.AuthorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        public IActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _authorService.Get(id);
            if(author == null)
            {
                return NotFound();
            }

            _authorService.Remove(author.AuthorId);

            return RedirectToAction(nameof(Index));
        }

        private bool authorExists(int id)
        {
            var author = _authorService.Get(id);
            return author!=null?true:false;
        }
    }
}