using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicrodadosEnemSergipe.WebApp.Data;
using MicrodadosEnemSergipe.WebApp.Helpers;

namespace MicrodadosEnemSergipe.WebApp.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly ContextConnection _context;

        public ParticipantesController(ContextConnection context)
        {
            _context = context;
        }

        // GET: Participantes
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 200;

            var participantes = _context.participante.AsQueryable();
            var paginatedList = await PaginatedList<Participante>.CreateAsync(participantes, page ?? 1, pageSize);

            return View(paginatedList);
        }

        // GET: Participantes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.participante
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // GET: Participantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroInscricao,AnoEnem,FaixaEtaria,Sexo,EstadoCivil,Raca,Nacionalidade,Treineiro")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participante);
        }

        // GET: Participantes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.participante.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroInscricao,AnoEnem,FaixaEtaria,Sexo,EstadoCivil,Raca,Nacionalidade,Treineiro")] Participante participante)
        {
            if (id != participante.NumeroInscricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipanteExists(participante.NumeroInscricao))
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
            return View(participante);
        }

        // GET: Participantes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.participante
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var participante = await _context.participante.FindAsync(id);
            if (participante != null)
            {
                _context.participante.Remove(participante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipanteExists(string id)
        {
            return _context.participante.Any(e => e.NumeroInscricao == id);
        }
    }
}
