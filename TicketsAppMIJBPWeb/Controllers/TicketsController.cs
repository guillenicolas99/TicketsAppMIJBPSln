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
    public class TicketsController : Controller
    {
        private readonly MiDbContext _context;

        public TicketsController(MiDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var miDbContext = _context.Tickets.Include(t => t.CategoriaTicketIdCategoriaTicketNavigation).Include(t => t.EstadoTicketIdEstadoTicketNavigation).Include(t => t.EventoIdEventoNavigation).Include(t => t.PersonaIdPersonaNavigation);
            return View(await miDbContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.CategoriaTicketIdCategoriaTicketNavigation)
                .Include(t => t.EstadoTicketIdEstadoTicketNavigation)
                .Include(t => t.EventoIdEventoNavigation)
                .Include(t => t.PersonaIdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdTicket == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["CategoriaTicketIdCategoriaTicket"] = new SelectList(_context.CategoriasTickets, "IdCategoriaTicket", "DescripcionCategoriaTicket");
            ViewData["EstadoTicketIdEstadoTicket"] = new SelectList(_context.EstadosTickets, "IdEstadoTicket", "DescripcionEstadoTicket");
            ViewData["EventoIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento");
            ViewData["PersonaIdPersona"] = new SelectList(_context.Personas, "IdPersona", "NombrePersona");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTicket,NumeroTicket,AbonoTicket,PrecioOriginal,DescuentoAplicado,FechaDescuento,EventoIdEvento,EstadoTicketIdEstadoTicket,CategoriaTicketIdCategoriaTicket,PersonaIdPersona")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaTicketIdCategoriaTicket"] = new SelectList(_context.CategoriasTickets, "IdCategoriaTicket", "DescripcionCategoriaTicket", ticket.CategoriaTicketIdCategoriaTicket);
            ViewData["EstadoTicketIdEstadoTicket"] = new SelectList(_context.EstadosTickets, "IdEstadoTicket", "DescripcionEstadoTicket", ticket.EstadoTicketIdEstadoTicket);
            ViewData["EventoIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", ticket.EventoIdEvento);
            ViewData["PersonaIdPersona"] = new SelectList(_context.Personas, "IdPersona", "NombrePersona", ticket.PersonaIdPersona);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["CategoriaTicketIdCategoriaTicket"] = new SelectList(_context.CategoriasTickets, "IdCategoriaTicket", "DescripcionCategoriaTicket", ticket.CategoriaTicketIdCategoriaTicket);
            ViewData["EstadoTicketIdEstadoTicket"] = new SelectList(_context.EstadosTickets, "IdEstadoTicket", "DescripcionEstadoTicket", ticket.EstadoTicketIdEstadoTicket);
            ViewData["EventoIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", ticket.EventoIdEvento);
            ViewData["PersonaIdPersona"] = new SelectList(_context.Personas, "IdPersona", "NombrePersona", ticket.PersonaIdPersona);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTicket,NumeroTicket,AbonoTicket,PrecioOriginal,DescuentoAplicado,FechaDescuento,EventoIdEvento,EstadoTicketIdEstadoTicket,CategoriaTicketIdCategoriaTicket,PersonaIdPersona")] Ticket ticket)
        {
            if (id != ticket.IdTicket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.IdTicket))
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
            ViewData["CategoriaTicketIdCategoriaTicket"] = new SelectList(_context.CategoriasTickets, "IdCategoriaTicket", "DescripcionCategoriaTicket", ticket.CategoriaTicketIdCategoriaTicket);
            ViewData["EstadoTicketIdEstadoTicket"] = new SelectList(_context.EstadosTickets, "IdEstadoTicket", "DescripcionEstadoTicket", ticket.EstadoTicketIdEstadoTicket);
            ViewData["EventoIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", ticket.EventoIdEvento);
            ViewData["PersonaIdPersona"] = new SelectList(_context.Personas, "IdPersona", "NombrePersona", ticket.PersonaIdPersona);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.CategoriaTicketIdCategoriaTicketNavigation)
                .Include(t => t.EstadoTicketIdEstadoTicketNavigation)
                .Include(t => t.EventoIdEventoNavigation)
                .Include(t => t.PersonaIdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdTicket == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.IdTicket == id);
        }
    }
}
