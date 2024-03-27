using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LocalDeAplicacao
{
    [Key]
    [Column("numero_inscricao")]
    public string? NumeroInscricao { get; set; }

    [Column("nome_municipio")]
    public string? NomeMunicipio { get; set; }

    [Column("codigo_municipio")]
    public int? CodigoMunicipio { get; set; }

    [Column("codigo_uf")]
    public int? CodigoUF { get; set; }

    [Column("sigla_uf")]
    public string? SiglaUF { get; set; }
}
