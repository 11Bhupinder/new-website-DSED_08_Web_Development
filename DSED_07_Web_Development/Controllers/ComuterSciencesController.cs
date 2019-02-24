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
    public class ComuterSciencesController : Controller
    {
        private readonly LibraryContext _context;

        public ComuterSciencesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: ComuterSciences
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComuterScience.ToListAsync());
        }

        // GET: ComuterSciences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comuterScience = await _context.ComuterScience
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (comuterScience == null)
            {
                return NotFound();
            }

            return View(comuterScience);
        }

        // GET: ComuterSciences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComuterSciences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,BookPrice,BookAuthor")] ComuterScience comuterScience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comuterScience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comuterScience);
        }

        // GET: ComuterSciences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comuterScience = await _context.ComuterScience.SingleOrDefaultAsync(m => m.BookId == id);
            if (comuterScience == null)
            {
                return NotFound();
            }
            return View(comuterScience);
        }

        // POST: ComuterSciences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,BookPrice,BookAuthor")] ComuterScience comuterScience)
        {
            if (id != comuterScience.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comuterScience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComuterScienceExists(comuterScience.BookId))
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
            return View(comuterScience);
        }

        // GET: ComuterSciences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comuterScience = await _context.ComuterScience
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (comuterScience == null)
            {
                return NotFound();
            }

            return View(comuterScience);
        }

        // POST: ComuterSciences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comuterScience = await _context.ComuterScience.SingleOrDefaultAsync(m => m.BookId == id);
            _context.ComuterScience.Remove(comuterScience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComuterScienceExists(int id)
        {
            return _context.ComuterScience.Any(e => e.BookId == id);
        }
    }
}
