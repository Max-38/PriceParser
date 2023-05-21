using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PriceParser.Data.EF.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbIdentit (this IServiceCollection services, string connectionString)
        {
            services.AddDbContext <ApplicationDbContext> (options =>
            {
                options.UseSqlite(connectionString);
            });

            return services;
        }
    }
}
