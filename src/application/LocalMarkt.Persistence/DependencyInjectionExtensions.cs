using LocalMarkt.Persistence.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LocalMarkt.Persistence
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddLocalMarktPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LocalMarktDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(PersistenceConstants.DbConnectionStringName)));
            
            return services;
        }
    }
}
