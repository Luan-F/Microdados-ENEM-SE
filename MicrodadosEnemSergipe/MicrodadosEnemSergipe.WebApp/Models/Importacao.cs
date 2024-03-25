using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temporario 
{
    [Table("tabelaimportacao", Schema = "temporario")]
    public class Importacao
    {
        [Key]
        [Column("numero_inscricao")]
        public string NumeroInscricao { get; set; }

        [Column("ano_enem")]
        public int? AnoEnem { get; set; }

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
        public bool? Treineiro { get; set; }

        [Column("situacao_conclusao")]
        public string? SituacaoConclusao { get; set; }

        [Column("ano_conclusao")]
        public int? AnoConclusao { get; set; }

        [Column("tipo_escola")]
        public string? TipoEscola { get; set; }

        [Column("tipo_ensino")]
        public string? TipoEnsino { get; set; }

        [Column("codigo_escola")]
        public string? CodigoEscola { get; set; }

        [Column("nome_municipio")]
        public string NomeMunicipio { get; set; }

        [Column("codigo_municipio")]
        public int? CodigoMunicipio { get; set; }

        [Column("codigo_uf")]
        public int? CodigoUF { get; set; }

        [Column("sigla_uf")]
        public string? SiglaUF { get; set; }

        [Column("dependencia_administrativa")]
        public string? DependenciaAdministrativa { get; set; }

        [Column("zona_localizacao")]
        public string? ZonaLocalizacao { get; set; }

        [Column("situcao_funcionamento")]
        public string? SituacaoFuncionamento { get; set; }

        [Column("presenca_cn")]
        public bool? PresencaCN { get; set; }

        [Column("presenca_ch")]
        public bool? PresencaCH { get; set; }

        [Column("presenca_lc")]
        public bool? PresencaLC { get; set; }

        [Column("presenca_mt")]
        public bool? PresencaMT { get; set; }

        [Column("cod_tipo_prova_cn")]
        public int? CodTipoProvaCN { get; set; }

        [Column("cod_tipo_prova_ch")]
        public int? CodTipoProvaCH { get; set; }

        [Column("cod_tipo_prova_lc")]
        public int? CodTipoProvaLC { get; set; }

        [Column("cod_tipo_prova_mt")]
        public int? CodTipoProvaMT { get; set; }

        [Column("nota_cn")]
        public double? NotaCN { get; set; }

        [Column("nota_ch")]
        public double? NotaCH { get; set; }

        [Column("nota_lc")]
        public double? NotaLC { get; set; }

        [Column("nota_mt")]
        public double? NotaMT { get; set; }

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

        [Column("status_redacao")]
        public string? StatusRedacao { get; set; }

        [Column("nota_comp1")]
        public double? NotaComp1 { get; set; }

        [Column("nota_comp2")]
        public double? NotaComp2 { get; set; }

        [Column("nota_comp3")]
        public double? NotaComp3 { get; set; }

        [Column("nota_comp4")]
        public double? NotaComp4 { get; set; }

        [Column("nota_comp5")]
        public double? NotaComp5 { get; set; }

        [Column("nota_redacao")]
        public double? NotaRedacao { get; set; }
    }
}