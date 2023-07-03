using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Interfaces;

namespace PriceParser.Data.EF
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPriceParserDb (this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<PriceParserDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Singleton);

            services.AddSingleton<IRequestResultRepository, RequestResultRepository>();

            return services;
        }
    }
}
