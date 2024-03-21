using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MicrodadosEnemSergipe.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "participante",
                columns: table => new
                {
                    numero_inscricao = table.Column<string>(type: "text", nullable: false),
                    ano_enem = table.Column<int>(type: "integer", nullable: false),
                    faixa_etaria = table.Column<string>(type: "text", nullable: true),
                    sexo = table.Column<string>(type: "text", nullable: true),
                    estado_civil = table.Column<string>(type: "text", nullable: true),
                    raca = table.Column<string>(type: "text", nullable: true),
                    nacionalidade = table.Column<string>(type: "text", nullable: true),
                    treineiro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participante", x => x.numero_inscricao);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isadministrador = table.Column<bool>(type: "boolean", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    senha = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participante");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
