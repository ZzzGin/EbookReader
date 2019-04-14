using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EbookReader.Data;
using EbookReader.Models;
using EbookReader.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using VersOne.Epub;

namespace EbookReader.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<IdentityUser> _userManager;

        public BooksController(ApplicationDbContext context, 
            IHostingEnvironment env,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookDbSet.Include(b => b.UploadedByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.BookDbSet
                .Include(b => b.UploadedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["UploadedByUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,BookCoverImagePath,Path,UploadedDateTime,UploadedByUserId")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UploadedByUserId"] = new SelectList(_context.Users, "Id", "Id", book.UploadedByUserId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.BookDbSet.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["UploadedByUserId"] = new SelectList(_context.Users, "Id", "Id", book.UploadedByUserId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BookName,BookCoverImagePath,Path,UploadedDateTime,UploadedByUserId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["UploadedByUserId"] = new SelectList(_context.Users, "Id", "Id", book.UploadedByUserId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.BookDbSet
                .Include(b => b.UploadedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var book = await _context.BookDbSet.FindAsync(id);
            _context.BookDbSet.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(Guid id)
        {
            return _context.BookDbSet.Any(e => e.Id == id);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadBookViewModel m)
        {
            var f = m.BookFile;
            var fName = m.BookName;
            var user = await _userManager.GetUserAsync(User);

            var folder = Path.Combine(_env.WebRootPath, "bookRepo", user.NormalizedUserName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var filePath = Path.Combine(folder, f.FileName);
            if (f.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await f.CopyToAsync(fileStream);
                }
            }

            EpubBook epubBook = EpubReader.ReadBook(filePath);
            byte[] coverImageContent = epubBook.CoverImage;
            var coverPath = Path.Combine(_env.WebRootPath, "bookCovers", Guid.NewGuid().ToString() + ".jpg");
            if (coverImageContent != null)
            {
                using (MemoryStream coverImageStream = new MemoryStream(coverImageContent))
                {
                    Image coverImage = Image.FromStream(coverImageStream);
                    coverImage = (Image)(new Bitmap(coverImage, new Size(140, 180)));
                    coverImage.Save(coverPath, ImageFormat.Jpeg);
                }
            }
            else
            {
                coverPath = null;
            }
            
            Book newBook = new Book
            {
                Id = Guid.NewGuid(),
                BookName = fName,
                BookCoverImagePath = coverPath,
                Path = filePath,
                UploadedDateTime = DateTime.Now,
                UploadedByUser = user,
            };
            _context.BookDbSet.Add(newBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
