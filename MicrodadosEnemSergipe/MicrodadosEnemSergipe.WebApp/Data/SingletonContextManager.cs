using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MicrodadosEnemSergipe.WebApp.Data
{
    public class SingletonContextManager
    {
        private static ContextConnection _instance;
        private static readonly object _lock = new object();
        private readonly IConfiguration _configuration;

        public SingletonContextManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ContextConnection GetContext()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<ContextConnection>();
                        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ContextConnection"));
                        _instance = new ContextConnection(optionsBuilder.Options);
                    }
                }
            }
            return _instance;
        }
    }
}
