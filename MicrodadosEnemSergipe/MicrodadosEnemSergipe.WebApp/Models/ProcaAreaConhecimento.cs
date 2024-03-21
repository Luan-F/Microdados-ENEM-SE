using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class ProvaAreaConhecimento
{
    [Key]
    [Column("numero_inscricao")]
    public string? NumeroInscricao { get; set; }

    [Column("presenca_cn")]
    public bool PresencaCN { get; set; }

    [Column("presenca_ch")]
    public bool PresencaCH { get; set; }

    [Column("presenca_lc")]
    public bool PresencaLC { get; set; }

    [Column("presenca_mt")]
    public bool PresencaMT { get; set; }

    [Column("cod_tipo_prova_cn")]
    public int CodTipoProvaCN { get; set; }

    [Column("cod_tipo_prova_ch")]
    public int CodTipoProvaCH { get; set; }

    [Column("cod_tipo_prova_lc")]
    public int CodTipoProvaLC { get; set; }

    [Column("cod_tipo_prova_mt")]
    public int CodTipoProvaMT { get; set; }

    [Column("nota_cn")]
    public float NotaCN { get; set; }

    [Column("nota_ch")]
    public float NotaCH { get; set; }

    [Column("nota_lc")]
    public float NotaLC { get; set; }

    [Column("nota_mt")]
    public float NotaMT { get; set; }

    [Column("vet_resp_cn")]
    public string? VetRespCN { get; set; }

    [Column("vet_resp_ch")]
    public string? VetRespCH { get; set; }

    [Column("vet_resp_lc")]
    public string? VetRespLC { get; set; }

    [Column("vet_resp_mt")]
    public string? VetRespMT { get; set; }

    [Column("vet_gab_cn")]
    public string? VetGabCN { get; set; }

    [Column("vet_gab_ch")]
    public string? VetGabCH { get; set; }

    [Column("vet_gab_lc")]
    public string? VetGabLC { get; set; }

    [Column("vet_gab_mt")]
    public string? VetGabMT { get; set; }

    [Column("lingua_estrangeira")]
    public string? LinguaEstrangeira { get; set; }
}
