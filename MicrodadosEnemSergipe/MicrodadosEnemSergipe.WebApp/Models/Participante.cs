using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Participante
{
    [Key]
    [Column("numero_inscricao")]
    public string? NumeroInscricao { get; set; }

    [Column("ano_enem")]
    public int AnoEnem { get; set; }

    [Column("faixa_etaria")]
    public string? FaixaEtaria { get; set; }

    [Column("sexo")]
    public string? Sexo { get; set; }

    [Column("estado_civil")]
    public string? EstadoCivil { get; set; }

    [Column("raca")]
    public string? Raca { get; set; }

    [Column("nacionalidade")]
    public string? Nacionalidade { get; set; }

    [Column("treineiro")]
    public int Treineiro { get; set; }
}
