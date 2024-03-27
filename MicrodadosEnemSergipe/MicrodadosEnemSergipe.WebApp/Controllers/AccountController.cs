using MicrodadosEnemSergipe.WebApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Temporario;

public class AccountController : Controller
{
    private readonly ContextConnection _context;

    public AccountController(ContextConnection context)
    {
        _context = context;
    }

    [Authorize]
    public IActionResult ImportDados()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ImportDados(IFormFile csvFile)
    {
        if (csvFile != null && csvFile.Length > 0)
        {
            try
            {
                List<Importacao> importacoes = new List<Importacao>();

                using (var reader = new StreamReader(csvFile.OpenReadStream()))
                {
                    // Ler a primeira linha para ignorar os cabeçalhos
                    await reader.ReadLineAsync();

                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var values = line.Split(' ');

                        // Tratar valores nulos ou vazios
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(values[i]))
                            {
                                // Se o valor for nulo ou vazio, substituir por um valor padrão
                                values[i] = string.Empty; // ou null, dependendo da preferência
                            }
                        }

                        // Criar uma nova instância de Importacao e adicionar à lista
                        var importacao = CriarImportacao(values);
                        importacoes.Add(importacao);
                    }
                }

                // Salvar as importações no banco de dados
                _context.importacao.AddRange(importacoes);
                await _context.SaveChangesAsync();

                return RedirectToAction("ImportacaoConcluida", "Account");
            }
            catch (Exception ex)
            {
                TempData["UploadError"] = $"Erro ao processar o arquivo CSV: {ex.Message}";
                return RedirectToAction("Login", "Account");
            }
        }

        TempData["UploadError"] = "Por favor, selecione um arquivo CSV.";
        return RedirectToAction("ImportDados");
    }
    private Importacao CriarImportacao(string[] values)
    {
        Importacao importacao = new Importacao();

        if (values.Length >= 48)
        {
            importacao.NumeroInscricao = values[0];
            importacao.AnoEnem = ParseInt(values[1]);
            importacao.FaixaEtaria = values[2];
            importacao.Sexo = values[3];
            importacao.EstadoCivil = values[4];
            importacao.Raca = values[5];
            importacao.Nacionalidade = values[6];
            importacao.Treineiro = ParseBool(values[7]);
            importacao.SituacaoConclusao = values[8];
            importacao.AnoConclusao = ParseInt(values[9]);
            importacao.TipoEscola = values[10];
            importacao.TipoEnsino = values[11];
            importacao.CodigoEscola = values[12];
            importacao.NomeMunicipio = values[13];
            importacao.CodigoMunicipio = ParseInt(values[14]);
            importacao.CodigoUF = ParseInt(values[15]);
            importacao.SiglaUF = values[16];
            importacao.DependenciaAdministrativa = values[17];
            importacao.ZonaLocalizacao = values[18];
            importacao.SituacaoFuncionamento = values[19];
            importacao.PresencaCN = ParseBool(values[20]);
            importacao.PresencaCH = ParseBool(values[21]);
            importacao.PresencaLC = ParseBool(values[22]);
            importacao.PresencaMT = ParseBool(values[23]);
            importacao.CodTipoProvaCN = ParseInt(values[24]);
            importacao.CodTipoProvaCH = ParseInt(values[25]);
            importacao.CodTipoProvaLC = ParseInt(values[26]);
            importacao.CodTipoProvaMT = ParseInt(values[27]);
            importacao.NotaCN = ParseDouble(values[28]);
            importacao.NotaCH = ParseDouble(values[29]);
            importacao.NotaLC = ParseDouble(values[30]);
            importacao.NotaMT = ParseDouble(values[31]);
            importacao.VetRespCN = values[32];
            importacao.VetRespCH = values[33];
            importacao.VetRespLC = values[34];
            importacao.VetRespMT = values[35];
            importacao.VetGabCN = values[36];
            importacao.VetGabCH = values[37];
            importacao.VetGabLC = values[38];
            importacao.VetGabMT = values[39];
            importacao.LinguaEstrangeira = values[40];
            importacao.StatusRedacao = values[41];
            importacao.NotaComp1 = ParseDouble(values[42]);
            importacao.NotaComp2 = ParseDouble(values[43]);
            importacao.NotaComp3 = ParseDouble(values[44]);
            importacao.NotaComp4 = ParseDouble(values[45]);
            importacao.NotaComp5 = ParseDouble(values[46]);
            importacao.NotaRedacao = ParseDouble(values[47]);
        }
        else
        {
            // Trate o caso em que o array values não tem o número esperado de elementos
            throw new ArgumentException("O array 'values' não tem o número esperado de elementos.");
        }

        return importacao;
    }
    // Função auxiliar para converter string para int com tratamento de valores nulos ou vazios
    private int ParseInt(string value)
    {
        int result;
        return int.TryParse(value, out result) ? result : 0; // Retorna 0 se não conseguir fazer a conversão
    }

    // Função auxiliar para converter string para bool com tratamento de valores nulos ou vazios
    private bool ParseBool(string value)
    {
        bool result;
        return bool.TryParse(value, out result) ? result : false; // Retorna false se não conseguir fazer a conversão
    }

    // Função auxiliar para converter string para double com tratamento de valores nulos ou vazios
    private double ParseDouble(string value)
    {
        double result;
        return double.TryParse(value, out result) ? result : 0.0; // Retorna 0.0 se não conseguir fazer a conversão
    }


    public IActionResult ImportacaoConcluida()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(string email, string senha)
    {
        var usuario = _context.usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);

        if (usuario != null)
        {
            var claims = new List<Claim>
            
            {
                new Claim(ClaimTypes.Name, usuario.Email),
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("ImportDados", "Account");
        }
        else
        {
            ViewData["ErrorMessage"] = "Email ou senha incorretos.";
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}

