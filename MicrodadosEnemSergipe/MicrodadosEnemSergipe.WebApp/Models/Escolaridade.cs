using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Escolaridade
{
    [Key]
    [Column("numero_inscricao")]
    public string? NumeroInscricao { get; set; }

    [Column("situacao_conclusao")]
    public string? SituacaoConclusao { get; set; }

    [Column("ano_conclusao")]
    public int AnoConclusao { get; set; }

    [Column("tipo_escola")]
    public string? TipoEscola { get; set; }

    [Column("tipo_ensino")]
    public string? TipoEnsino { get; set; }

    [Column("codigo_escola")]
    public string? CodigoEscola { get; set; }

    [Column("nome_municipio")]
    public string? NomeMunicipio { get; set; }

    [Column("codigo_municipio")]
    public int CodigoMunicipio { get; set; }

    [Column("codigo_uf")]
    public int CodigoUF { get; set; }

    [Column("sigla_uf")]
    public string? SiglaUF { get; set; }

    [Column("dependencia_administrativa")]
    public string? DependenciaAdministrativa { get; set; }

    [Column("zona_localizacao")]
    public string? ZonaLocalizacao { get; set; }

    [Column("situcao_funcionamento")]
    public string? SitucaoFuncionamento { get; set; }
}
