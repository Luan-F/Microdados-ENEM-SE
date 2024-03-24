using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using MicrodadosEnemSergipe.WebApp.Models;

namespace testando.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var mediaGeralDeCadaMunicio = 
                new ChartData(new List<string> { "January", "February", "March", "April" }, new List<int> { 10, 20, 30, 40 });
            var desempenhoPorAreaDoConhecimento = 
                new ChartData(
                    new List<string> { "Linguagens e Códigos", "Matemática e suas Tecnologias", "Ciências Humanas", "Ciências da Natureza", "Redação" }, 
                    new List<int> { 10, 20, 30, 40 });
            var mediaPorPresenca = 
                new ChartData(new List<string> { "January", "February", "March", "April" }, new List<int> { 550, 420, 660, 560, 740 });

            var model = new HomeViewModel
            {
                MediaGeralDeCadaMunicipio = mediaGeralDeCadaMunicio,
                MediaPorPresenca = mediaPorPresenca,
                DesempenhoPorAreaDoConhecimento = desempenhoPorAreaDoConhecimento
            };

            return View(model);
        }
        public IActionResult Readme()
        {
            return View();
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
