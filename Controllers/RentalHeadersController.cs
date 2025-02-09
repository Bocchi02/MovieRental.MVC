using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.MVC.Data;
using MovieRental.MVC.Models;

namespace MovieRental.MVC.Controllers
{
    public class RentalHeadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalHeaders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentalHeader.Include(r => r.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentalHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalHeader = await _context.RentalHeader
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.RentalHeaderId == id);
            if (rentalHeader == null)
            {
                return NotFound();
            }

            return View(rentalHeader);
        }

        // GET: RentalHeaders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View();
        }

        // POST: RentalHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalHeaderId,CustomerId,RentalDate,ReturnDate")] RentalHeader rentalHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", rentalHeader.CustomerId);
            return View(rentalHeader);
        }

        // GET: RentalHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalHeader = await _context.RentalHeader.FindAsync(id);
            if (rentalHeader == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", rentalHeader.CustomerId);
            return View(rentalHeader);
        }

        // POST: RentalHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalHeaderId,CustomerId,RentalDate,ReturnDate")] RentalHeader rentalHeader)
        {
            if (id != rentalHeader.RentalHeaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalHeaderExists(rentalHeader.RentalHeaderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", rentalHeader.CustomerId);
            return View(rentalHeader);
        }

        // GET: RentalHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalHeader = await _context.RentalHeader
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.RentalHeaderId == id);
            if (rentalHeader == null)
            {
                return NotFound();
            }

            return View(rentalHeader);
        }

        // POST: RentalHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalHeader = await _context.RentalHeader.FindAsync(id);
            if (rentalHeader != null)
            {
                _context.RentalHeader.Remove(rentalHeader);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalHeaderExists(int id)
        {
            return _context.RentalHeader.Any(e => e.RentalHeaderId == id);
        }
    }
}
