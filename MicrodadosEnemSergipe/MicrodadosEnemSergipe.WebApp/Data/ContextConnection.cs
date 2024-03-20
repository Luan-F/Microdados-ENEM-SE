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
    }
}
