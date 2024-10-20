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
    public class RedesController : Controller
    {
        private readonly MiDbContext _context;

        public RedesController(MiDbContext context)
        {
            _context = context;
        }

        // GET: Redes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Redes.ToListAsync());
        }

        // GET: Redes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rede = await _context.Redes
                .FirstOrDefaultAsync(m => m.IdRed == id);
            if (rede == null)
            {
                return NotFound();
            }

            return View(rede);
        }

        // GET: Redes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Redes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRed,NombreRed,DescripcionRed")] Rede rede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rede);
        }

        // GET: Redes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rede = await _context.Redes.FindAsync(id);
            if (rede == null)
            {
                return NotFound();
            }
            return View(rede);
        }

        // POST: Redes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRed,NombreRed,DescripcionRed")] Rede rede)
        {
            if (id != rede.IdRed)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedeExists(rede.IdRed))
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
            return View(rede);
        }

        // GET: Redes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rede = await _context.Redes
                .FirstOrDefaultAsync(m => m.IdRed == id);
            if (rede == null)
            {
                return NotFound();
            }

            return View(rede);
        }

        // POST: Redes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rede = await _context.Redes.FindAsync(id);
            if (rede != null)
            {
                _context.Redes.Remove(rede);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedeExists(int id)
        {
            return _context.Redes.Any(e => e.IdRed == id);
        }
    }
}
