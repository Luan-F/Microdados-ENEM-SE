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
        return View();
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
