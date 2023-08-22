using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Data;
using Client.Model;

namespace Client.Controllers
{
    public class Clientes1Controller : Controller
    {
        private readonly AppDbContext _context;

        public Clientes1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clientes1
        public async Task<IActionResult> Index()
        {
              return _context._Clientes != null ? 
                          View(await _context._Clientes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext._Clientes'  is null.");
        }

        // GET: Clientes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context._Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context._Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Descripcion,FechaCreacion,Estatus")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: Clientes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context._Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context._Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Descripcion,FechaCreacion,Estatus")] Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.Id))
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
            return View(clientes);
        }

        // GET: Clientes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context._Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context._Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context._Clientes == null)
            {
                return Problem("Entity set 'AppDbContext._Clientes'  is null.");
            }
            var clientes = await _context._Clientes.FindAsync(id);
            if (clientes != null)
            {
                _context._Clientes.Remove(clientes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
          return (_context._Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
