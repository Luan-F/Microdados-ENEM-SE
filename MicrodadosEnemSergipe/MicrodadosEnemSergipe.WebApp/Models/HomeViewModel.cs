namespace MicrodadosEnemSergipe.WebApp.Models;

public class HomeViewModel
{
    public ChartData MediaGeralDeCadaMunicipio { get; set; }
    public ChartData DesempenhoPorAreaDoConhecimento { get; set; }
    public ChartData MediaPorPresenca { get; set; }
}

public record ChartData(List<string> Labels, List<int> Data);