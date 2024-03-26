using Temporario;

public interface IDadosGeraisStrategy
{
    DadosGeraisViewModel CalcularDadosGerais(IEnumerable<Importacao> dados);
}
