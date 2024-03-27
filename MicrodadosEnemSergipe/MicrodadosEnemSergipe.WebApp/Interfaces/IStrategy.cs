using Temporario;

public interface IStrategy
{
    DadosGeraisViewModel CalcularDadosGerais(IEnumerable<Importacao> dados);
}
