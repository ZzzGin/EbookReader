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
    public class JoinBookShelfBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JoinBookShelfBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JoinBookShelfBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JoinBookShelfBookDbSet.Include(j => j.Book).Include(j => j.BookShelf);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JoinBookShelfBooks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joinBookShelfBook = await _context.JoinBookShelfBookDbSet
                .Include(j => j.Book)
                .Include(j => j.BookShelf)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (joinBookShelfBook == null)
            {
                return NotFound();
            }

            return View(joinBookShelfBook);
        }

        // GET: JoinBookShelfBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id");
            ViewData["BookShelfId"] = new SelectList(_context.BookShelfDbSet, "Id", "Id");
            return View();
        }

        // POST: JoinBookShelfBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookShelfId,BookId")] JoinBookShelfBook joinBookShelfBook)
        {
            if (ModelState.IsValid)
            {
                // joinBookShelfBook.BookId = Guid.NewGuid();
                _context.Add(joinBookShelfBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id", joinBookShelfBook.BookId);
            ViewData["BookShelfId"] = new SelectList(_context.BookShelfDbSet, "Id", "Id", joinBookShelfBook.BookShelfId);
            return View(joinBookShelfBook);
        }

        // GET: JoinBookShelfBooks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joinBookShelfBook = await _context.JoinBookShelfBookDbSet.FindAsync(id);
            if (joinBookShelfBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id", joinBookShelfBook.BookId);
            ViewData["BookShelfId"] = new SelectList(_context.BookShelfDbSet, "Id", "Id", joinBookShelfBook.BookShelfId);
            return View(joinBookShelfBook);
        }

        // POST: JoinBookShelfBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookShelfId,BookId")] JoinBookShelfBook joinBookShelfBook)
        {
            if (id != joinBookShelfBook.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joinBookShelfBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoinBookShelfBookExists(joinBookShelfBook.BookId))
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
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id", joinBookShelfBook.BookId);
            ViewData["BookShelfId"] = new SelectList(_context.BookShelfDbSet, "Id", "Id", joinBookShelfBook.BookShelfId);
            return View(joinBookShelfBook);
        }

        // GET: JoinBookShelfBooks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joinBookShelfBook = await _context.JoinBookShelfBookDbSet
                .Include(j => j.Book)
                .Include(j => j.BookShelf)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (joinBookShelfBook == null)
            {
                return NotFound();
            }

            return View(joinBookShelfBook);
        }

        // POST: JoinBookShelfBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var joinBookShelfBook = await _context.JoinBookShelfBookDbSet.FindAsync(id);
            _context.JoinBookShelfBookDbSet.Remove(joinBookShelfBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoinBookShelfBookExists(Guid id)
        {
            return _context.JoinBookShelfBookDbSet.Any(e => e.BookId == id);
        }
    }
}
