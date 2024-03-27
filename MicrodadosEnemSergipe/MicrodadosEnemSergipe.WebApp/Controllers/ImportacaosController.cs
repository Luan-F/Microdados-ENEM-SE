// ImportacaosController.cs

using Microsoft.AspNetCore.Mvc;
using MicrodadosEnemSergipe.WebApp.Data;
using Temporario;
using System.Collections.Generic;
using MicrodadosEnemSergipe.WebApp.Helpers;
using System.Linq;

public class ImportacaosController : Controller
{
    private readonly IStrategy _strategy;

    private readonly SingletonContextManager _context;

    public ImportacaosController(IStrategy strategy, SingletonContextManager context)
    {
        this._strategy = strategy;

        this._context = context;
    }

    public IActionResult ExibicaoTabela()
    {
        var dbContext = _context.GetContext();

        var dados = dbContext.importacao
           .Where(m => m.CodigoUF == 28) // Filtra apenas pelo código UF 28
           .GroupBy(m => m.NomeMunicipio) // Agrupa por município
           .Select(g => g.ToList()) // Converte cada grupo em uma lista
           .ToList(); // Converte para uma lista

        var resultado = dados.Select(d => _strategy.CalcularDadosGerais(d));

        return View(resultado);
    }

    public IActionResult Graficos()
    {
        var dbContext = _context.GetContext();

        var dadosImportacao = dbContext.importacao.ToList();

        var mediasPorAreaConhecimento = dadosImportacao
            .GroupBy(d => d.NomeMunicipio)
            .Select(g => new
            {
                NomeMunicipio = g.Key,
                MediaNotaCH = g.Average(d => d.NotaCH),
                MediaNotaLC = g.Average(d => d.NotaLC),
                MediaNotaMT = g.Average(d => d.NotaMT),
                MediaNotaCN = g.Average(d => d.NotaCN),
                MediaPresenca = g.Average(d => ((bool)d.PresencaCN ? 1 : 0) + ((bool)d.PresencaCH ? 1 : 0) + ((bool)d.PresencaMT ? 1 : 0) + ((bool)d.PresencaLC ? 1 : 0)),
                MediaNotaRedacao = g.Average(m => m.NotaRedacao)
            })
            .ToList();

        var data = new
        {
            Municipios = mediasPorAreaConhecimento.Select(m => m.NomeMunicipio),
            MediasNotaCH = mediasPorAreaConhecimento.Select(m => m.MediaNotaCH),
            MediasNotaLC = mediasPorAreaConhecimento.Select(m => m.MediaNotaLC),
            MediasNotaMT = mediasPorAreaConhecimento.Select(m => m.MediaNotaMT),
            MediasNotaCN = mediasPorAreaConhecimento.Select(m => m.MediaNotaCN),
            MediasPresenca = mediasPorAreaConhecimento.Select(m => m.MediaPresenca),
            MediasNotaRedacao = mediasPorAreaConhecimento.Select(m => m.MediaNotaRedacao)
        };

        return View(data);
    }


    public async Task<IActionResult> TabelaParticipantes(int? page)
    {
	var pageSize = 15;
	var dbContext = _context.GetContext();

	AbstractQueryClass dados = new ParticipanteQueries(dbContext);

	var participanteQueries = new ParticipanteQueries(dbContext);
	participanteQueries.CopyFromAbstract(dados);
	var paginedList = await PaginatedList<ParticipanteDados>.CreateAsync(participanteQueries.ExecuteJoin(), page ?? 1, pageSize);

	return View(paginedList);
    }
}
