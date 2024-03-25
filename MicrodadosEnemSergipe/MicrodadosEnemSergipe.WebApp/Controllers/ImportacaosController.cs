using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicrodadosEnemSergipe.WebApp.Data;
using Temporario;

namespace MicrodadosEnemSergipe.WebApp.Controllers
{
    public class ImportacaosController : Controller
    {
        private readonly ContextConnection _context;

        public ImportacaosController(ContextConnection context)
        {
            _context = context;
        }

        // GET: Importacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.importacao.ToListAsync());
        }

        public IActionResult ExibicaoTabela()
        {
            var resultados = _context.importacao
                .Where(m => m.CodigoUF == 28) // Filtra apenas pelo código UF 28
                .GroupBy(m => m.NomeMunicipio) // Agrupa por município
                .Select(g => new DadosGeraisViewModel
                {
                    NomeMunicipio = g.Key,
                    MediaNotaCN = (decimal)g.Average(m => m.NotaCN),
                    MediaNotaCH = (decimal)g.Average(m => m.NotaCH),
                    MediaNotaLC = (decimal)g.Average(m => m.NotaLC),
                    MediaNotaMT = (decimal)g.Average(m => m.NotaMT),
                    NotaTotal = (decimal)g.Average(m => (m.NotaCN + m.NotaCH + m.NotaLC + m.NotaMT) / 4),
                    MediaNotaComp1 = (decimal)g.Average(m => m.NotaComp1),
                    MediaNotaComp2 = (decimal)g.Average(m => m.NotaComp2),
                    MediaNotaComp3 = (decimal)g.Average(m => m.NotaComp3),
                    MediaNotaComp4 = (decimal)g.Average(m => m.NotaComp4),
                    MediaNotaComp5 = (decimal)g.Average(m => m.NotaComp5),
                    MediaNotaRedacao = (decimal)g.Average(m => m.NotaRedacao)
                })
                .ToList();

            return View(resultados);
        }


        // GET: Importacaos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importacao = await _context.importacao
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (importacao == null)
            {
                return NotFound();
            }

            return View(importacao);
        }

        // GET: Importacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Importacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroInscricao,AnoEnem,FaixaEtaria,Sexo,EstadoCivil,Raca,Nacionalidade,Treineiro,SituacaoConclusao,AnoConclusao,TipoEscola,TipoEnsino,CodigoEscola,NomeMunicipio,CodigoMunicipio,CodigoUF,SiglaUF,DependenciaAdministrativa,ZonaLocalizacao,SituacaoFuncionamento,PresencaCN,PresencaCH,PresencaLC,PresencaMT,CodTipoProvaCN,CodTipoProvaCH,CodTipoProvaLC,CodTipoProvaMT,NotaCN,NotaCH,NotaLC,NotaMT,VetRespCN,VetRespCH,VetRespLC,VetRespMT,VetGabCN,VetGabCH,VetGabLC,VetGabMT,LinguaEstrangeira,StatusRedacao,NotaComp1,NotaComp2,NotaComp3,NotaComp4,NotaComp5,NotaRedacao")] Importacao importacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importacao);
        }

        // GET: Importacaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importacao = await _context.importacao.FindAsync(id);
            if (importacao == null)
            {
                return NotFound();
            }
            return View(importacao);
        }

        // POST: Importacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroInscricao,AnoEnem,FaixaEtaria,Sexo,EstadoCivil,Raca,Nacionalidade,Treineiro,SituacaoConclusao,AnoConclusao,TipoEscola,TipoEnsino,CodigoEscola,NomeMunicipio,CodigoMunicipio,CodigoUF,SiglaUF,DependenciaAdministrativa,ZonaLocalizacao,SituacaoFuncionamento,PresencaCN,PresencaCH,PresencaLC,PresencaMT,CodTipoProvaCN,CodTipoProvaCH,CodTipoProvaLC,CodTipoProvaMT,NotaCN,NotaCH,NotaLC,NotaMT,VetRespCN,VetRespCH,VetRespLC,VetRespMT,VetGabCN,VetGabCH,VetGabLC,VetGabMT,LinguaEstrangeira,StatusRedacao,NotaComp1,NotaComp2,NotaComp3,NotaComp4,NotaComp5,NotaRedacao")] Importacao importacao)
        {
            if (id != importacao.NumeroInscricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportacaoExists(importacao.NumeroInscricao))
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
            return View(importacao);
        }

        // GET: Importacaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importacao = await _context.importacao
                .FirstOrDefaultAsync(m => m.NumeroInscricao == id);
            if (importacao == null)
            {
                return NotFound();
            }

            return View(importacao);
        }

        // POST: Importacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var importacao = await _context.importacao.FindAsync(id);
            if (importacao != null)
            {
                _context.importacao.Remove(importacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportacaoExists(string id)
        {
            return _context.importacao.Any(e => e.NumeroInscricao == id);
        }
    }
}
