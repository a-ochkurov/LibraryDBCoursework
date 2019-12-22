using BookLibrary.BLL.Interfaces;
using BookLibrary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace borrowLibrary.Web.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly IBorrowService _borrowService;

        public BorrowsController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        public IActionResult Index()
        {
            var borrow = _borrowService.Get();

            return View(borrow);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = _borrowService.Get(id.Value);

            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BorrowId,ReaderId,BookId,TakenDate,BroughtDate")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                _borrowService.Add(borrow);

                return RedirectToAction(nameof(Index));
            }

            return View(borrow);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = _borrowService.Get(id.Value);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int borrowId, [Bind("BorrowId,ReaderId,BookId,TakenDate,BroughtDate")]  Borrow borrow)
        {
            if (borrowId != borrow.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _borrowService.Update(borrow);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!borrowExists(borrow.BorrowId))
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

            return View(borrow);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = _borrowService.Get(id.Value);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var borrow = _borrowService.Get(id);
            if (borrow == null)
            {
                return NotFound();
            }

            _borrowService.Remove(borrow.BorrowId);

            return RedirectToAction(nameof(Index));
        }

        private bool borrowExists(int id)
        {
            var borrow = _borrowService.Get(id);
            return borrow != null ? true : false;
        }
    }
}