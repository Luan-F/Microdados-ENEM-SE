//namespace MicrodadosEnemSergipe.WebApp.Models
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    [Key]
    [Column("id")]
    public int ID { get; set; }

    [Column("isadministrador")]
    public bool IsAdministrador { get; set; }

    [Column("nome")]

    public string? Nome { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("senha")]
    public string? Senha { get; set; }
}