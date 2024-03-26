﻿using System;
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
        public async Task<IActionResult> Index(string searchString, string searchString1)
        {
            // Check if user email exists in cookies
            var userEmail = Request.Cookies["UserEmail"];

            if (!string.IsNullOrEmpty(userEmail))
            {
                IQueryable<DatiExAllievi> datiExAllieviQuery = _context.DatiExAllievi;

                if (!string.IsNullOrEmpty(searchString))
                {
                    datiExAllieviQuery = datiExAllieviQuery.Where(s => s.Specializzazione!.Contains(searchString));
                }

                if (!string.IsNullOrEmpty(searchString1) && decimal.TryParse(searchString1, out decimal stipendioRichiesto))
                {
                    datiExAllieviQuery = datiExAllieviQuery.Where(s => s.StipendioMensileRichiesto == stipendioRichiesto);
                }

                // Filter ex-alumni data by user email
                var datiExAllievi = await datiExAllieviQuery
                    .Where(d => d.Email == userEmail)
                    .ToListAsync();

                return View(datiExAllievi);
            }
            else
            {
                // If user email is not found in cookies, return an error
                return Problem("UTENTE NON ESISTENTE, CHIEDERE ALL'AMMINISTRATORE DI ESSERE AGGIUNTI");
            }
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

        [HttpPost]
        [Authorize(Roles = "Ex allievo")]
        public async Task<IActionResult> Upload(UploadViewModel model, DatiExAllievi datiExAllievi)
        {
            if (model.File != null && model.File.Length > 0)
            {
                var fileName = Path.GetFileName(model.File.FileName);
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var filePath = Path.Combine(uploadsDirectory, fileName);

                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }

                datiExAllievi.CurriculumFilePath = filePath;

                var existingRecord = _context.DatiExAllievi.FirstOrDefault(a => a.CodiceFiscale == datiExAllievi.CodiceFiscale);
                if (existingRecord != null)
                {
                    existingRecord.CurriculumFilePath = filePath;
                    _context.Update(existingRecord);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var codiceFiscaleFromEmail = _context.DatiExAllievi
                                                    .Where(a => a.Email == datiExAllievi.Email)
                                                    .Select(a => a.CodiceFiscale)
                                                    .FirstOrDefault();

                    if (!string.IsNullOrEmpty(codiceFiscaleFromEmail))
                    {
                        datiExAllievi.CodiceFiscale = codiceFiscaleFromEmail;
                    }

                    _context.Add(datiExAllievi);
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("File", "Please select a file.");
            return View(model);
        }

        [Authorize(Roles = "Ex allievo")]
        public IActionResult CaricaCurriculum()
        {
            return View();
        }

        // GET: DatiExAllievis/Create
        [Authorize(Roles = "Ex allievo")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatiExAllievis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Ex allievo")]
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
        [Authorize(Roles = "Ex allievo")]
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
        [Authorize(Roles = "Ex allievo")]
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
        [Authorize(Roles = "Ex allievo")]
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
        [Authorize(Roles = "Ex allievo")]
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
