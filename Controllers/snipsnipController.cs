using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using snipsnip.Models;

namespace snipsnip.Controllers
{
    public class snipsnipController : Controller
    {
        private readonly MyDbContext _context;

        public snipsnipController(MyDbContext context)
        {
            _context = context;    
        }

        // GET: snipsnip
        public async Task<IActionResult> Index()
        {
            return View(await _context.snipsnip.ToListAsync());
        }

        // GET: snipsnip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snip = await _context.snipsnip.SingleOrDefaultAsync(m => m.ID == id);
            if (snip == null)
            {
                return NotFound();
            }

            return View(snip);
        }

        // GET: snipsnip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: snipsnip/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Code,Language")] snip snip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(snip);
        }

        // GET: snipsnip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snip = await _context.snipsnip.SingleOrDefaultAsync(m => m.ID == id);
            if (snip == null)
            {
                return NotFound();
            }
            return View(snip);
        }

        // POST: snipsnip/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Code,Language")] snip snip)
        {
            if (id != snip.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!snipExists(snip.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(snip);
        }

        // GET: snipsnip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snip = await _context.snipsnip.SingleOrDefaultAsync(m => m.ID == id);
            if (snip == null)
            {
                return NotFound();
            }

            return View(snip);
        }

        // POST: snipsnip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snip = await _context.snipsnip.SingleOrDefaultAsync(m => m.ID == id);
            _context.snipsnip.Remove(snip);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool snipExists(int id)
        {
            return _context.snipsnip.Any(e => e.ID == id);
        }
    }
}
