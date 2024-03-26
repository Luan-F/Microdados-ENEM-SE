using Temporario;

public class MediaSimplesDadosGeraisStrategy : IDadosGeraisStrategy
{
    public DadosGeraisViewModel CalcularDadosGerais(IEnumerable<Importacao> dados)
    {
        return new DadosGeraisViewModel
        {
            NomeMunicipio = dados.First().NomeMunicipio,
            MediaNotaCN = (decimal)dados.Average(m => m.NotaCN),
            MediaNotaCH = (decimal)dados.Average(m => m.NotaCH),
            MediaNotaLC = (decimal)dados.Average(m => m.NotaLC),
            MediaNotaMT = (decimal)dados.Average(m => m.NotaMT),
            NotaTotal = (decimal)dados.Average(m => (m.NotaCN + m.NotaCH + m.NotaLC + m.NotaMT) / 4),
            MediaNotaComp1 = (decimal)dados.Average(m => m.NotaComp1),
            MediaNotaComp2 = (decimal)dados.Average(m => m.NotaComp2),
            MediaNotaComp3 = (decimal)dados.Average(m => m.NotaComp3),
            MediaNotaComp4 = (decimal)dados.Average(m => m.NotaComp4),
            MediaNotaComp5 = (decimal)dados.Average(m => m.NotaComp5),
            MediaPresenca = (decimal)(dados.Average(m => ((bool)m.PresencaCN ? 1 : 0) + ((bool)m.PresencaCH ? 1 : 0) + ((bool)m.PresencaMT ? 1 : 0) + ((bool)m.PresencaLC ? 1 : 0)) / 4),
            MediaNotaRedacao = (decimal)dados.Average(m => m.NotaRedacao)
        };
    }
}
