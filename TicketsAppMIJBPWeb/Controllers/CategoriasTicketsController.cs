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
    public class CategoriasTicketsController : Controller
    {
        private readonly MiDbContext _context;

        public CategoriasTicketsController(MiDbContext context)
        {
            _context = context;
        }

        // GET: CategoriasTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriasTickets.ToListAsync());
        }

        // GET: CategoriasTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasTicket = await _context.CategoriasTickets
                .FirstOrDefaultAsync(m => m.IdCategoriaTicket == id);
            if (categoriasTicket == null)
            {
                return NotFound();
            }

            return View(categoriasTicket);
        }

        // GET: CategoriasTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriasTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaTicket,NombreCategoriaTicket,DescripcionCategoriaTicket,DescuentoAplicable")] CategoriasTicket categoriasTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriasTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriasTicket);
        }

        // GET: CategoriasTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasTicket = await _context.CategoriasTickets.FindAsync(id);
            if (categoriasTicket == null)
            {
                return NotFound();
            }
            return View(categoriasTicket);
        }

        // POST: CategoriasTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoriaTicket,NombreCategoriaTicket,DescripcionCategoriaTicket,DescuentoAplicable")] CategoriasTicket categoriasTicket)
        {
            if (id != categoriasTicket.IdCategoriaTicket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriasTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriasTicketExists(categoriasTicket.IdCategoriaTicket))
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
            return View(categoriasTicket);
        }

        // GET: CategoriasTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasTicket = await _context.CategoriasTickets
                .FirstOrDefaultAsync(m => m.IdCategoriaTicket == id);
            if (categoriasTicket == null)
            {
                return NotFound();
            }

            return View(categoriasTicket);
        }

        // POST: CategoriasTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriasTicket = await _context.CategoriasTickets.FindAsync(id);
            if (categoriasTicket != null)
            {
                _context.CategoriasTickets.Remove(categoriasTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasTicketExists(int id)
        {
            return _context.CategoriasTickets.Any(e => e.IdCategoriaTicket == id);
        }
    }
}
