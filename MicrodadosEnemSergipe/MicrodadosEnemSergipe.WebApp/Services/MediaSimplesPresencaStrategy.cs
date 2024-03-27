using Temporario;

public class MediaSimplesstrategy : IStrategy
{
    public DadosGeraisViewModel CalcularDadosGerais(IEnumerable<Importacao> dados)
    {
        return new DadosGeraisViewModel
        {
            NomeMunicipio = dados.First().NomeMunicipio,
            MediaNotaCN = (int)dados.Average(m => m.NotaCN),
            MediaNotaCH = (int)dados.Average(m => m.NotaCH),
            MediaNotaLC = (int)dados.Average(m => m.NotaLC),
            MediaNotaMT = (int)dados.Average(m => m.NotaMT),
            NotaTotal = (int)dados.Average(m => (m.NotaCN + m.NotaCH + m.NotaLC + m.NotaMT) / 4),
            MediaNotaComp1 = (int)dados.Average(m => m.NotaComp1),
            MediaNotaComp2 = (int)dados.Average(m => m.NotaComp2),
            MediaNotaComp3 = (int)dados.Average(m => m.NotaComp3),
            MediaNotaComp4 = (int)dados.Average(m => m.NotaComp4),
            MediaNotaComp5 = (int)dados.Average(m => m.NotaComp5),
            MediaPresenca = (decimal)(dados.Average(m => ((bool)m.PresencaCN ? 1 : 0) + ((bool)m.PresencaCH ? 1 : 0) + 
            ((bool)m.PresencaMT ? 1 : 0) + ((bool)m.PresencaLC ? 1 : 0)) / 4),
            MediaNotaRedacao = (int)dados.Average(m => m.NotaRedacao)
        };
    }
}
