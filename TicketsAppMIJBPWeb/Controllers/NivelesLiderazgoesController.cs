using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapaInfraestructura.CapaDominio.Entities;
using CapaInfraestructura.Context;

namespace TicketsAppMIJBPWeb.Controllers
{
    public class NivelesLiderazgoesController : Controller
    {
        private readonly MiDbContext _context;

        public NivelesLiderazgoesController(MiDbContext context)
        {
            _context = context;
        }

        // GET: NivelesLiderazgoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelesLiderazgos.ToListAsync());
        }

        // GET: NivelesLiderazgoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelesLiderazgo = await _context.NivelesLiderazgos
                .FirstOrDefaultAsync(m => m.IdNivelLiderazgo == id);
            if (nivelesLiderazgo == null)
            {
                return NotFound();
            }

            return View(nivelesLiderazgo);
        }

        // GET: NivelesLiderazgoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelesLiderazgoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNivelLiderazgo,NombreNivel,DescripcionNivel")] NivelesLiderazgo nivelesLiderazgo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelesLiderazgo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelesLiderazgo);
        }

        // GET: NivelesLiderazgoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelesLiderazgo = await _context.NivelesLiderazgos.FindAsync(id);
            if (nivelesLiderazgo == null)
            {
                return NotFound();
            }
            return View(nivelesLiderazgo);
        }

        // POST: NivelesLiderazgoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNivelLiderazgo,NombreNivel,DescripcionNivel")] NivelesLiderazgo nivelesLiderazgo)
        {
            if (id != nivelesLiderazgo.IdNivelLiderazgo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelesLiderazgo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelesLiderazgoExists(nivelesLiderazgo.IdNivelLiderazgo))
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
            return View(nivelesLiderazgo);
        }

        // GET: NivelesLiderazgoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelesLiderazgo = await _context.NivelesLiderazgos
                .FirstOrDefaultAsync(m => m.IdNivelLiderazgo == id);
            if (nivelesLiderazgo == null)
            {
                return NotFound();
            }

            return View(nivelesLiderazgo);
        }

        // POST: NivelesLiderazgoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivelesLiderazgo = await _context.NivelesLiderazgos.FindAsync(id);
            if (nivelesLiderazgo != null)
            {
                _context.NivelesLiderazgos.Remove(nivelesLiderazgo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelesLiderazgoExists(int id)
        {
            return _context.NivelesLiderazgos.Any(e => e.IdNivelLiderazgo == id);
        }
    }
}
