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
    public class EventoController : Controller
    {
        private readonly MiDbContext _context;

        public EventoController(MiDbContext context)
        {
            _context = context;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            var miDbContext = _context.Eventos.Include(e => e.EstadoEventoIdEstadoEventoNavigation);
            return View(await miDbContext.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.EstadoEventoIdEstadoEventoNavigation)
                .Include(e => e.Tickets)
                    .ThenInclude(t => t.EstadoTicketIdEstadoTicketNavigation)
                .Include(e => e.Tickets)
                    .ThenInclude(t => t.CategoriaTicketIdCategoriaTicketNavigation)
                .Include(e => e.Tickets)
                    .ThenInclude(t => t.PersonaIdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoEventoIdEstadoEvento"] = new SelectList(_context.EstadosEventos, "IdEstadoEvento", "NombreEstadoEvento");
            return View();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEvento,NombreEvento,FechaEvento,CantidadTotalTickets,DescripcionEvento,EstadoEventoIdEstadoEvento")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoEventoIdEstadoEvento"] = new SelectList(_context.EstadosEventos, "IdEstadoEvento", "DescripcionEstadoEvento", evento.EstadoEventoIdEstadoEvento);
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["NombreEstadoEvento"] = new SelectList(_context.EstadosEventos, "IdEstadoEvento", "NombreEstadoEvento", evento.EstadoEventoIdEstadoEvento);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEvento,NombreEvento,FechaEvento,CantidadTotalTickets,DescripcionEvento,EstadoEventoIdEstadoEvento")] Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.IdEvento))
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
            ViewData["EstadoEventoIdEstadoEvento"] = new SelectList(_context.EstadosEventos, "IdEstadoEvento", "DescripcionEstadoEvento", evento.EstadoEventoIdEstadoEvento);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.EstadoEventoIdEstadoEventoNavigation)
                .FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.IdEvento == id);
        }
    }
}
