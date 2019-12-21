using BookLibrary.BLL.Interfaces;
using BookLibrary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Controllers
{
    public class ReadersController : Controller
    {
        private readonly IReaderService _readerService;

        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        public IActionResult Index()
        {
            var reader = _readerService.Get();

            return View(reader);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = _readerService.Get(id.Value);

            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ReaderId, FirstName, LastName")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                _readerService.Add(reader);

                return RedirectToAction(nameof(Index));
            }

            return View(reader);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = _readerService.Get(id.Value);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int readerId, [Bind("ReaderId, FirstName, LastName")]Reader reader)
        {
            if (readerId != reader.ReaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _readerService.Update(reader);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!readerExists(reader.ReaderId))
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

            return View(reader);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = _readerService.Get(id.Value);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reader = _readerService.Get(id);
            if (reader == null)
            {
                return NotFound();
            }

            _readerService.Remove(reader.ReaderId);

            return RedirectToAction(nameof(Index));
        }

        private bool readerExists(int id)
        {
            var reader = _readerService.Get(id);
            return reader != null ? true : false;
        }
    }
}