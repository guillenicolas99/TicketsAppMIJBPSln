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
    public class EstadosTicketsController : Controller
    {
        private readonly MiDbContext _context;

        public EstadosTicketsController(MiDbContext context)
        {
            _context = context;
        }

        // GET: EstadosTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadosTickets.ToListAsync());
        }

        // GET: EstadosTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosTicket = await _context.EstadosTickets
                .FirstOrDefaultAsync(m => m.IdEstadoTicket == id);
            if (estadosTicket == null)
            {
                return NotFound();
            }

            return View(estadosTicket);
        }

        // GET: EstadosTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoTicket,NombreEstadoTicket,DescripcionEstadoTicket")] EstadosTicket estadosTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosTicket);
        }

        // GET: EstadosTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosTicket = await _context.EstadosTickets.FindAsync(id);
            if (estadosTicket == null)
            {
                return NotFound();
            }
            return View(estadosTicket);
        }

        // POST: EstadosTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoTicket,NombreEstadoTicket,DescripcionEstadoTicket")] EstadosTicket estadosTicket)
        {
            if (id != estadosTicket.IdEstadoTicket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosTicketExists(estadosTicket.IdEstadoTicket))
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
            return View(estadosTicket);
        }

        // GET: EstadosTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosTicket = await _context.EstadosTickets
                .FirstOrDefaultAsync(m => m.IdEstadoTicket == id);
            if (estadosTicket == null)
            {
                return NotFound();
            }

            return View(estadosTicket);
        }

        // POST: EstadosTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadosTicket = await _context.EstadosTickets.FindAsync(id);
            if (estadosTicket != null)
            {
                _context.EstadosTickets.Remove(estadosTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosTicketExists(int id)
        {
            return _context.EstadosTickets.Any(e => e.IdEstadoTicket == id);
        }
    }
}
