using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Redacao
{
    [Key]
    [Column("numero_inscricao")]
    public string? NumeroInscricao { get; set; }

    [Column("status_redacao")]
    public string? StatusRedacao { get; set; }

    [Column("nota_comp1")]
    public float NotaComp1 { get; set; }

    [Column("nota_comp2")]
    public float NotaComp2 { get; set; }

    [Column("nota_comp3")]
    public float NotaComp3 { get; set; }

    [Column("nota_comp4")]
    public float NotaComp4 { get; set; }

    [Column("nota_comp5")]
    public float NotaComp5 { get; set; }

    [Column("nota_redacao")]
    public float NotaRedacao { get; set; }
}
