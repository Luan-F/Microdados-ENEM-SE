using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MicrodadosEnemSergipe.WebApp.Data
{
    public class ContextConnection : DbContext
    {
        public ContextConnection(DbContextOptions<ContextConnection> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Participante> participante { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<LocalDeAplicacao> localdeaplicacao { get; set; }
        public DbSet<Redacao> redacao { get; set; }
        public DbSet<Escolaridade> escolaridade { get; set; }
        public DbSet<ProvaAreaConhecimento> provaareaconhecimento { get; set; }
    }
}
