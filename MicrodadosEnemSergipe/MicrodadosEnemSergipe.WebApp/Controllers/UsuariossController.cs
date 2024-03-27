using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicrodadosEnemSergipe.WebApp.Data;

namespace MicrodadosEnemSergipe.WebApp.Controllers
{
    public class UsuariossController : Controller
    {
        private readonly SingletonContextManager _context;

        public UsuariossController(SingletonContextManager context)
        {
            _context = context;
        }

        // GET: Usuarioss
        public async Task<IActionResult> Index()
        {

            var dbContext = _context.GetContext();

            return View(await dbContext.usuario.ToListAsync());
        }

        // GET: Usuarioss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dbContext = _context.GetContext();

            var usuario = await dbContext.usuario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarioss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarioss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IsAdministrador,Nome,Email,Senha")] Usuario usuario)
        {
            var dbContext = _context.GetContext();
            if (ModelState.IsValid)
            {
                dbContext.Add(usuario);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarioss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var dbContext = _context.GetContext();
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await dbContext.usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarioss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IsAdministrador,Nome,Email,Senha")] Usuario usuario)
        {
            var dbContext = _context.GetContext();
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(usuario);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.ID))
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
            return View(usuario);
        }

        // GET: Usuarioss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var dbContext = _context.GetContext();
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await dbContext.usuario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarioss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbContext = _context.GetContext();
            var usuario = await dbContext.usuario.FindAsync(id);
            if (usuario != null)
            {
                dbContext.usuario.Remove(usuario);
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            var dbContext = _context.GetContext();
            return dbContext.usuario.Any(e => e.ID == id);
        }
    }
}
