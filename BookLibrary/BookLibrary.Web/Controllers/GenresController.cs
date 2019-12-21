using BookLibrary.BLL.Interfaces;
using BookLibrary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var genre = _genreService.Get();

            return View(genre);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _genreService.Get(id.Value);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GenreId, GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Add(genre);

                return RedirectToAction(nameof(Index));
            }

            return View(genre);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _genreService.Get(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int genreId, [Bind("GenreId, GenreName")] Genre genre)
        {
            if (genreId != genre.GenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _genreService.Update(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!genreExists(genre.GenreId))
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

            return View(genre);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _genreService.Get(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var genre = _genreService.Get(id);
            if (genre == null)
            {
                return NotFound();
            }

            _genreService.Remove(genre.GenreId);

            return RedirectToAction(nameof(Index));
        }

        private bool genreExists(int id)
        {
            var genre = _genreService.Get(id);
            return genre != null ? true : false;
        }
    }
}