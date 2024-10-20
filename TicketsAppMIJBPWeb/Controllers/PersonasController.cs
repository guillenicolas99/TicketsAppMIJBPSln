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
    public class PersonasController : Controller
    {
        private readonly MiDbContext _context;

        public PersonasController(MiDbContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var miDbContext = _context.Personas.Include(p => p.NivelLiderazgoIdNivelLiderazgoNavigation).Include(p => p.RedIdRedNavigation);
            return View(await miDbContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.NivelLiderazgoIdNivelLiderazgoNavigation)
                .Include(p => p.RedIdRedNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["NivelLiderazgoIdNivelLiderazgo"] = new SelectList(_context.NivelesLiderazgos, "IdNivelLiderazgo", "DescripcionNivel");
            ViewData["RedIdRed"] = new SelectList(_context.Redes, "IdRed", "NombreRed");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,NombrePersona,Email,Telefono,NivelLiderazgoIdNivelLiderazgo,RedIdRed")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NivelLiderazgoIdNivelLiderazgo"] = new SelectList(_context.NivelesLiderazgos, "IdNivelLiderazgo", "DescripcionNivel", persona.NivelLiderazgoIdNivelLiderazgo);
            ViewData["RedIdRed"] = new SelectList(_context.Redes, "IdRed", "NombreRed", persona.RedIdRed);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["NivelLiderazgoIdNivelLiderazgo"] = new SelectList(_context.NivelesLiderazgos, "IdNivelLiderazgo", "DescripcionNivel", persona.NivelLiderazgoIdNivelLiderazgo);
            ViewData["RedIdRed"] = new SelectList(_context.Redes, "IdRed", "NombreRed", persona.RedIdRed);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,NombrePersona,Email,Telefono,NivelLiderazgoIdNivelLiderazgo,RedIdRed")] Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
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
            ViewData["NivelLiderazgoIdNivelLiderazgo"] = new SelectList(_context.NivelesLiderazgos, "IdNivelLiderazgo", "DescripcionNivel", persona.NivelLiderazgoIdNivelLiderazgo);
            ViewData["RedIdRed"] = new SelectList(_context.Redes, "IdRed", "NombreRed", persona.RedIdRed);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.NivelLiderazgoIdNivelLiderazgoNavigation)
                .Include(p => p.RedIdRedNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
