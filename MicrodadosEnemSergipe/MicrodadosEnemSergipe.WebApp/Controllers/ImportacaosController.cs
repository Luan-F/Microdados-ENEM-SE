// ImportacaosController.cs

using Microsoft.AspNetCore.Mvc;
using MicrodadosEnemSergipe.WebApp.Data;
using Temporario;
using System.Collections.Generic;
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
       AbstractQueryClass abstractQuery = new MunicipioQueries(dbContext);
       var query = new MunicipioQueries(dbContext);
       query.CopyFromAbstract(abstractQuery);
       var dados = query.ExecuteJoin()
	       .ToList();

        var resultado = dados;

        return View(resultado);
    }

    public IActionResult Graficos()
    {
        return View();
    }


}
