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
    public class ProvaAreaConhecimentoesController : Controller
    {
        private readonly ContextConnection _context;

        public ProvaAreaConhecimentoesController(ContextConnection context)
        {
            _context = context;
        }

        // GET: ProvaAreaConhecimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.provaareaconhecimento.ToListAsync());
        }

        // GET: ProvaAreaConhecimentoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provaAreaConhecimento = await _context.provaareaconhecimento
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (provaAreaConhecimento == null)
            {
                return NotFound();
            }

            return View(provaAreaConhecimento);
        }

        // GET: ProvaAreaConhecimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProvaAreaConhecimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroInscricao,PresencaCN,PresencaCH,PresencaLC,PresencaMT,CodTipoProvaCN,CodTipoProvaCH,CodTipoProvaLC,CodTipoProvaMT,NotaCN,NotaCH,NotaLC,NotaMT,VetRespCN,VetRespCH,VetRespLC,VetRespMT,VetGabCN,VetGabCH,VetGabLC,VetGabMT,LinguaEstrangeira")] ProvaAreaConhecimento provaAreaConhecimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provaAreaConhecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provaAreaConhecimento);
        }

        // GET: ProvaAreaConhecimentoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provaAreaConhecimento = await _context.provaareaconhecimento.FindAsync(id);
            if (provaAreaConhecimento == null)
            {
                return NotFound();
            }
            return View(provaAreaConhecimento);
        }

        // POST: ProvaAreaConhecimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroInscricao,PresencaCN,PresencaCH,PresencaLC,PresencaMT,CodTipoProvaCN,CodTipoProvaCH,CodTipoProvaLC,CodTipoProvaMT,NotaCN,NotaCH,NotaLC,NotaMT,VetRespCN,VetRespCH,VetRespLC,VetRespMT,VetGabCN,VetGabCH,VetGabLC,VetGabMT,LinguaEstrangeira")] ProvaAreaConhecimento provaAreaConhecimento)
        {
            if (id != provaAreaConhecimento.NumeroInscricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provaAreaConhecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvaAreaConhecimentoExists(provaAreaConhecimento.NumeroInscricao))
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
            return View(provaAreaConhecimento);
        }

        // GET: ProvaAreaConhecimentoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provaAreaConhecimento = await _context.provaareaconhecimento
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (provaAreaConhecimento == null)
            {
                return NotFound();
            }

            return View(provaAreaConhecimento);
        }

        // POST: ProvaAreaConhecimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var provaAreaConhecimento = await _context.provaareaconhecimento.FindAsync(id);
            if (provaAreaConhecimento != null)
            {
                _context.provaareaconhecimento.Remove(provaAreaConhecimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvaAreaConhecimentoExists(string id)
        {
            return _context.provaareaconhecimento.Any(e => e.NumeroInscricao == id);
        }
    }
}
