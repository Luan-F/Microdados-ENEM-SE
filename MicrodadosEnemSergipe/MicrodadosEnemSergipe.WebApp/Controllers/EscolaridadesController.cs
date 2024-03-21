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
    public class EscolaridadesController : Controller
    {
        private readonly ContextConnection _context;

        public EscolaridadesController(ContextConnection context)
        {
            _context = context;
        }

        // GET: Escolaridades
        public async Task<IActionResult> Index()
        {
            return View(await _context.escolaridade.ToListAsync());
        }

        // GET: Escolaridades/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridade = await _context.escolaridade
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (escolaridade == null)
            {
                return NotFound();
            }

            return View(escolaridade);
        }

        // GET: Escolaridades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolaridades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroInscricao,SituacaoConclusao,AnoConclusao,TipoEscola,TipoEnsino,CodigoEscola,NomeMunicipio,CodigoMunicipio,CodigoUF,SiglaUF,DependenciaAdministrativa,ZonaLocalizacao,SitucaoFuncionamento")] Escolaridade escolaridade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escolaridade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escolaridade);
        }

        // GET: Escolaridades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridade = await _context.escolaridade.FindAsync(id);
            if (escolaridade == null)
            {
                return NotFound();
            }
            return View(escolaridade);
        }

        // POST: Escolaridades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroInscricao,SituacaoConclusao,AnoConclusao,TipoEscola,TipoEnsino,CodigoEscola,NomeMunicipio,CodigoMunicipio,CodigoUF,SiglaUF,DependenciaAdministrativa,ZonaLocalizacao,SitucaoFuncionamento")] Escolaridade escolaridade)
        {
            if (id != escolaridade.NumeroInscricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolaridade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaridadeExists(escolaridade.NumeroInscricao))
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
            return View(escolaridade);
        }

        // GET: Escolaridades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridade = await _context.escolaridade
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (escolaridade == null)
            {
                return NotFound();
            }

            return View(escolaridade);
        }

        // POST: Escolaridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var escolaridade = await _context.escolaridade.FindAsync(id);
            if (escolaridade != null)
            {
                _context.escolaridade.Remove(escolaridade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaridadeExists(string id)
        {
            return _context.escolaridade.Any(e => e.NumeroInscricao == id);
        }
    }
}
