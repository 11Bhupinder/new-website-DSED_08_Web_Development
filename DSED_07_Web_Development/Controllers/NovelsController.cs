using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSED_07_Web_Development.Models;

namespace DSED_07_Web_Development.Controllers
{
    public class NovelsController : Controller
    {
        private readonly LibraryContext _context;

        public NovelsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Novels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Novels.ToListAsync());
        }

        // GET: Novels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novels = await _context.Novels
                .SingleOrDefaultAsync(m => m.NovelId == id);
            if (novels == null)
            {
                return NotFound();
            }

            return View(novels);
        }

        // GET: Novels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Novels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovelId,NovelName,NovelPrice,NovelAuthor")] Novels novels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novels);
        }

        // GET: Novels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novels = await _context.Novels.SingleOrDefaultAsync(m => m.NovelId == id);
            if (novels == null)
            {
                return NotFound();
            }
            return View(novels);
        }

        // POST: Novels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovelId,NovelName,NovelPrice,NovelAuthor")] Novels novels)
        {
            if (id != novels.NovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovelsExists(novels.NovelId))
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
            return View(novels);
        }

        // GET: Novels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novels = await _context.Novels
                .SingleOrDefaultAsync(m => m.NovelId == id);
            if (novels == null)
            {
                return NotFound();
            }

            return View(novels);
        }

        // POST: Novels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novels = await _context.Novels.SingleOrDefaultAsync(m => m.NovelId == id);
            _context.Novels.Remove(novels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovelsExists(int id)
        {
            return _context.Novels.Any(e => e.NovelId == id);
        }
    }
}
