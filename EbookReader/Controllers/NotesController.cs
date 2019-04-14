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
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NoteDbSet.Include(n => n.Book).Include(n => n.CreateByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.NoteDbSet
                .Include(n => n.Book)
                .Include(n => n.CreateByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id");
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,Location,BookContent,NoteContent,CreateByUserId")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.Id = Guid.NewGuid();
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id", note.BookId);
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id", note.CreateByUserId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.NoteDbSet.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id", note.BookId);
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id", note.CreateByUserId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BookId,Location,BookContent,NoteContent,CreateByUserId")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
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
            ViewData["BookId"] = new SelectList(_context.BookDbSet, "Id", "Id", note.BookId);
            ViewData["CreateByUserId"] = new SelectList(_context.Users, "Id", "Id", note.CreateByUserId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.NoteDbSet
                .Include(n => n.Book)
                .Include(n => n.CreateByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var note = await _context.NoteDbSet.FindAsync(id);
            _context.NoteDbSet.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(Guid id)
        {
            return _context.NoteDbSet.Any(e => e.Id == id);
        }
    }
}
