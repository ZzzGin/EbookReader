using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EbookReader.Data;
using EbookReader.Models;

namespace EbookReader.Controllers
{
    public class BookShelvesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookShelvesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookShelves
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookShelfDbSet.Include(b => b.CreateByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookShelves/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShelf = await _context.BookShelfDbSet
                .Include(b => b.CreateByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookShelf == null)
            {
                return NotFound();
            }

            return View(bookShelf);
        }

        // GET: BookShelves/Create
        public IActionResult Create()
        {
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: BookShelves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookShelfName,Description,CreateByUserId")] BookShelf bookShelf)
        {
            if (ModelState.IsValid)
            {
                bookShelf.Id = Guid.NewGuid();
                _context.Add(bookShelf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id", bookShelf.CreateByUserId);
            return View(bookShelf);
        }

        // GET: BookShelves/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShelf = await _context.BookShelfDbSet.FindAsync(id);
            if (bookShelf == null)
            {
                return NotFound();
            }
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id", bookShelf.CreateByUserId);
            return View(bookShelf);
        }

        // POST: BookShelves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BookShelfName,Description,CreateByUserId")] BookShelf bookShelf)
        {
            if (id != bookShelf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookShelf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookShelfExists(bookShelf.Id))
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
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id", bookShelf.CreateByUserId);
            return View(bookShelf);
        }

        // GET: BookShelves/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShelf = await _context.BookShelfDbSet
                .Include(b => b.CreateByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookShelf == null)
            {
                return NotFound();
            }

            return View(bookShelf);
        }

        // POST: BookShelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bookShelf = await _context.BookShelfDbSet.FindAsync(id);
            _context.BookShelfDbSet.Remove(bookShelf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookShelfExists(Guid id)
        {
            return _context.BookShelfDbSet.Any(e => e.Id == id);
        }
    }
}
