using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeApp.Models;

namespace CoffeeApp.Controllers
{
    public class CoffeesController : Controller
    {
        private readonly MyDbContext _context;

        public CoffeesController(MyDbContext context)
        {
            _context = context;    
        }

        // GET: Coffees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coffees.ToListAsync());
        }

        // GET: Coffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees.SingleOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // GET: Coffees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coffees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Origin,Roast,Brand,ExpirationDate")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: Coffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees.SingleOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Origin,Roast,Brand,ExpirationDate")] Coffee coffee)
        {
            if (id != coffee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeExists(coffee.ID))
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
            return View(coffee);
        }

        // GET: Coffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees.SingleOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffee = await _context.Coffees.SingleOrDefaultAsync(m => m.ID == id);
            _context.Coffees.Remove(coffee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CoffeeExists(int id)
        {
            return _context.Coffees.Any(e => e.ID == id);
        }
    }
}
