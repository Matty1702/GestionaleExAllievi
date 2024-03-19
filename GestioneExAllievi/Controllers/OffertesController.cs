using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestioneExAllievi.Data;
using GestioneExAllievi.Models;
using Microsoft.AspNetCore.Authorization;

namespace GestioneExAllievi.Controllers
{
    [Authorize]
    public class OffertesController : Controller
    {
        private readonly GestioneExAllieviContext _context;

        public OffertesController(GestioneExAllieviContext context)
        {
            _context = context;
        }

        // GET: Offertes
        public async Task<IActionResult> Index(string searchString2, string searchString3)
        {
            if (_context.Offerte == null)
            {
                return Problem("Entity set 'GestioneExAllieviContext.Offerte' is null.");
            }

            var offerte = from d in _context.Offerte
                                select d;

            if (!String.IsNullOrEmpty(searchString2))
            {
                offerte = offerte.Where(s => s.Specializzazione!.Contains(searchString2));
            }

            if (!String.IsNullOrEmpty(searchString3))
            {
                decimal Salario;
                if (!decimal.TryParse(searchString3, out Salario))
                {
                    return View(await offerte.ToListAsync());
                }
                else
                {
                    offerte = offerte.Where(s => s.Salario == Salario);
                }
            }

            return View(await offerte.ToListAsync());
        }


        // GET: Offertes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Offerte == null)
            {
                return NotFound();
            }

            var offerte = await _context.Offerte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerte == null)
            {
                return NotFound();
            }

            return View(offerte);
        }

        // GET: Offertes/Create
        [Authorize(Roles = "Azienda")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offertes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Azienda")]
        public async Task<IActionResult> Create([Bind("Id,Titolo,Specializzazione,Descrizione,Luogo,Salario")] Offerte offerte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerte);
        }

        // GET: Offertes/Edit/5
        [Authorize(Roles = "Azienda")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Offerte == null)
            {
                return NotFound();
            }

            var offerte = await _context.Offerte.FindAsync(id);
            if (offerte == null)
            {
                return NotFound();
            }
            return View(offerte);
        }

        // POST: Offertes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Azienda")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titolo,Specializzazione,Descrizione,Luogo,Salario")] Offerte offerte)
        {
            if (id != offerte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferteExists(offerte.Id))
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
            return View(offerte);
        }

        // GET: Offertes/Delete/5
        [Authorize(Roles = "Azienda")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Offerte == null)
            {
                return NotFound();
            }

            var offerte = await _context.Offerte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerte == null)
            {
                return NotFound();
            }

            return View(offerte);
        }

        // POST: Offertes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Azienda")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Offerte == null)
            {
                return Problem("Entity set 'GestioneExAllieviContext.Offerte'  is null.");
            }
            var offerte = await _context.Offerte.FindAsync(id);
            if (offerte != null)
            {
                _context.Offerte.Remove(offerte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferteExists(int id)
        {
          return (_context.Offerte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
