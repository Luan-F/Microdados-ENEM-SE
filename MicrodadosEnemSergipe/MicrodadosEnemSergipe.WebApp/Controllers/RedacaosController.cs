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
    public class RedacaosController : Controller
    {
        private readonly ContextConnection _context;

        public RedacaosController(ContextConnection context)
        {
            _context = context;
        }

        // GET: Redacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.redacao.ToListAsync());
        }

        // GET: Redacaos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redacao = await _context.redacao
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (redacao == null)
            {
                return NotFound();
            }

            return View(redacao);
        }

        // GET: Redacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Redacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroInscricao,StatusRedacao,NotaComp1,NotaComp2,NotaComp3,NotaComp4,NotaComp5,NotaRedacao")] Redacao redacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(redacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(redacao);
        }

        // GET: Redacaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redacao = await _context.redacao.FindAsync(id);
            if (redacao == null)
            {
                return NotFound();
            }
            return View(redacao);
        }

        // POST: Redacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroInscricao,StatusRedacao,NotaComp1,NotaComp2,NotaComp3,NotaComp4,NotaComp5,NotaRedacao")] Redacao redacao)
        {
            if (id != redacao.NumeroInscricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(redacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedacaoExists(redacao.NumeroInscricao))
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
            return View(redacao);
        }

        // GET: Redacaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redacao = await _context.redacao
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (redacao == null)
            {
                return NotFound();
            }

            return View(redacao);
        }

        // POST: Redacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var redacao = await _context.redacao.FindAsync(id);
            if (redacao != null)
            {
                _context.redacao.Remove(redacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedacaoExists(string id)
        {
            return _context.redacao.Any(e => e.NumeroInscricao == id);
        }
    }
}
