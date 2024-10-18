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
    public class EstadosEventoController : Controller
    {
        private readonly MiDbContext _context;

        public EstadosEventoController(MiDbContext context)
        {
            _context = context;
        }

        // GET: EstadosEvento
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadosEventos.ToListAsync());
        }

        // GET: EstadosEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosEvento = await _context.EstadosEventos
                .FirstOrDefaultAsync(m => m.IdEstadoEvento == id);
            if (estadosEvento == null)
            {
                return NotFound();
            }

            return View(estadosEvento);
        }

        // GET: EstadosEvento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosEvento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoEvento,NombreEstadoEvento,DescripcionEstadoEvento")] EstadosEvento estadosEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosEvento);
        }

        // GET: EstadosEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosEvento = await _context.EstadosEventos.FindAsync(id);
            if (estadosEvento == null)
            {
                return NotFound();
            }
            return View(estadosEvento);
        }

        // POST: EstadosEvento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoEvento,NombreEstadoEvento,DescripcionEstadoEvento")] EstadosEvento estadosEvento)
        {
            if (id != estadosEvento.IdEstadoEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosEventoExists(estadosEvento.IdEstadoEvento))
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
            return View(estadosEvento);
        }

        // GET: EstadosEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosEvento = await _context.EstadosEventos
                .FirstOrDefaultAsync(m => m.IdEstadoEvento == id);
            if (estadosEvento == null)
            {
                return NotFound();
            }

            return View(estadosEvento);
        }

        // POST: EstadosEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadosEvento = await _context.EstadosEventos.FindAsync(id);
            if (estadosEvento != null)
            {
                _context.EstadosEventos.Remove(estadosEvento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosEventoExists(int id)
        {
            return _context.EstadosEventos.Any(e => e.IdEstadoEvento == id);
        }
    }
}
