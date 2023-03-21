using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreDemo.Context;
using EFCoreDemo.Models;

namespace EFCoreDemo.Controllers
{
    public class KitapsController : Controller
    {
        private readonly EFCoreDemoContext _context;

        public KitapsController(EFCoreDemoContext context)
        {
            _context = context;
        }

        // GET: Kitaps
        public async Task<IActionResult> Index()
        {
            var eFCoreDemoContext = _context.Kitaps.Include(k => k.Yazar);
            return View(await eFCoreDemoContext.ToListAsync());
        }

        // GET: Kitaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kitaps == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaps
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // GET: Kitaps/Create
        public IActionResult Create()
        {
            ViewData["YazarID"] = new SelectList(_context.Yazars, "ID", "ID");
            return View();
        }

        // POST: Kitaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Type,YazarID")] Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["YazarID"] = new SelectList(_context.Yazars, "ID", "ID", kitap.YazarID);
            return View(kitap);
        }

        // GET: Kitaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kitaps == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaps.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["YazarID"] = new SelectList(_context.Yazars, "ID", "ID", kitap.YazarID);
            return View(kitap);
        }

        // POST: Kitaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Type,YazarID")] Kitap kitap)
        {
            if (id != kitap.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapExists(kitap.ID))
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
            ViewData["YazarID"] = new SelectList(_context.Yazars, "ID", "ID", kitap.YazarID);
            return View(kitap);
        }

        // GET: Kitaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kitaps == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaps
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kitaps == null)
            {
                return Problem("Entity set 'EFCoreDemoContext.Kitaps'  is null.");
            }
            var kitap = await _context.Kitaps.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaps.Remove(kitap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapExists(int id)
        {
          return (_context.Kitaps?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
