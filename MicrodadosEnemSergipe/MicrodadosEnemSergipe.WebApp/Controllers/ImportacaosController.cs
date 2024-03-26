// ImportacaosController.cs

using Microsoft.AspNetCore.Mvc;
using MicrodadosEnemSergipe.WebApp.Data;
using Temporario;
using System.Collections.Generic;
using System.Linq;

public class ImportacaosController : Controller
{
    private readonly IDadosGeraisStrategy _dadosGeraisStrategy;
    private readonly ContextConnection _context;

    public ImportacaosController(IDadosGeraisStrategy dadosGeraisStrategy, ContextConnection context)
    {
        _dadosGeraisStrategy = dadosGeraisStrategy;
        _context = context;
    }

    public IActionResult ExibicaoTabela()
    {
        var dados = _context.importacao
           .Where(m => m.CodigoUF == 28) // Filtra apenas pelo código UF 28
           .GroupBy(m => m.NomeMunicipio) // Agrupa por município
           .Select(g => g.ToList()) // Converte cada grupo em uma lista
           .ToList(); // Converte para uma lista

        var resultado = dados.Select(d => _dadosGeraisStrategy.CalcularDadosGerais(d));

        return View(resultado);
    }


}
