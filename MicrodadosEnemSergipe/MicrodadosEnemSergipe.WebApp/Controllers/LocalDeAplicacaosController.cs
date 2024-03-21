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
    public class LocalDeAplicacaosController : Controller
    {
        private readonly ContextConnection _context;

        public LocalDeAplicacaosController(ContextConnection context)
        {
            _context = context;
        }

        // GET: LocalDeAplicacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.localdeaplicacao.ToListAsync());
        }

        // GET: LocalDeAplicacaos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localDeAplicacao = await _context.localdeaplicacao
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (localDeAplicacao == null)
            {
                return NotFound();
            }

            return View(localDeAplicacao);
        }

        // GET: LocalDeAplicacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalDeAplicacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroInscricao,NomeMunicipio,CodigoMunicipio,CodigoUF,SiglaUF")] LocalDeAplicacao localDeAplicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localDeAplicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localDeAplicacao);
        }

        // GET: LocalDeAplicacaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localDeAplicacao = await _context.localdeaplicacao.FindAsync(id);
            if (localDeAplicacao == null)
            {
                return NotFound();
            }
            return View(localDeAplicacao);
        }

        // POST: LocalDeAplicacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroInscricao,NomeMunicipio,CodigoMunicipio,CodigoUF,SiglaUF")] LocalDeAplicacao localDeAplicacao)
        {
            if (id != localDeAplicacao.NumeroInscricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localDeAplicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalDeAplicacaoExists(localDeAplicacao.NumeroInscricao))
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
            return View(localDeAplicacao);
        }

        // GET: LocalDeAplicacaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localDeAplicacao = await _context.localdeaplicacao
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (localDeAplicacao == null)
            {
                return NotFound();
            }

            return View(localDeAplicacao);
        }

        // POST: LocalDeAplicacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var localDeAplicacao = await _context.localdeaplicacao.FindAsync(id);
            if (localDeAplicacao != null)
            {
                _context.localdeaplicacao.Remove(localDeAplicacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalDeAplicacaoExists(string id)
        {
            return _context.localdeaplicacao.Any(e => e.NumeroInscricao == id);
        }
    }
}
