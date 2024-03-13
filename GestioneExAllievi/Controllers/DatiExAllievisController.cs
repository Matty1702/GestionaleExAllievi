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
    public class DatiExAllievisController : Controller
    {
        private readonly GestioneExAllieviContext _context;

        public DatiExAllievisController(GestioneExAllieviContext context)
        {
            _context = context;
        }

        // GET: DatiExAllievis
        public async Task<IActionResult> Index()
        {
              return _context.DatiExAllievi != null ? 
                          View(await _context.DatiExAllievi.ToListAsync()) :
                          Problem("Entity set 'GestioneExAllieviContext.DatiExAllievi'  is null.");
        }

        // GET: DatiExAllievis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DatiExAllievi == null)
            {
                return NotFound();
            }

            var datiExAllievi = await _context.DatiExAllievi
                .FirstOrDefaultAsync(m => m.CodiceFiscale == id);
            if (datiExAllievi == null)
            {
                return NotFound();
            }

            return View(datiExAllievi);
        }

        // GET: DatiExAllievis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatiExAllievis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodiceFiscale,Nome,Cognome,Indirizzo,NumTelefono,Email,SocialMedia,UsernamesSocialMedia,TitoloDiStudio,Specializzazione,FrequentaUniversita,CercaLavoro,EOccupato,StipendioMensileAttuale,StipendioMensileRichiesto,CurriculumFilePath")] DatiExAllievi datiExAllievi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datiExAllievi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datiExAllievi);
        }

        // GET: DatiExAllievis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DatiExAllievi == null)
            {
                return NotFound();
            }

            var datiExAllievi = await _context.DatiExAllievi.FindAsync(id);
            if (datiExAllievi == null)
            {
                return NotFound();
            }
            return View(datiExAllievi);
        }

        // POST: DatiExAllievis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodiceFiscale,Nome,Cognome,Indirizzo,NumTelefono,Email,SocialMedia,UsernamesSocialMedia,TitoloDiStudio,Specializzazione,FrequentaUniversita,CercaLavoro,EOccupato,StipendioMensileAttuale,StipendioMensileRichiesto,CurriculumFilePath")] DatiExAllievi datiExAllievi)
        {
            if (id != datiExAllievi.CodiceFiscale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datiExAllievi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatiExAllieviExists(datiExAllievi.CodiceFiscale))
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
            return View(datiExAllievi);
        }

        // GET: DatiExAllievis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DatiExAllievi == null)
            {
                return NotFound();
            }

            var datiExAllievi = await _context.DatiExAllievi
                .FirstOrDefaultAsync(m => m.CodiceFiscale == id);
            if (datiExAllievi == null)
            {
                return NotFound();
            }

            return View(datiExAllievi);
        }

        // POST: DatiExAllievis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DatiExAllievi == null)
            {
                return Problem("Entity set 'GestioneExAllieviContext.DatiExAllievi'  is null.");
            }
            var datiExAllievi = await _context.DatiExAllievi.FindAsync(id);
            if (datiExAllievi != null)
            {
                _context.DatiExAllievi.Remove(datiExAllievi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatiExAllieviExists(string id)
        {
          return (_context.DatiExAllievi?.Any(e => e.CodiceFiscale == id)).GetValueOrDefault();
        }
    }
}
