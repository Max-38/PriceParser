using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Services;
using System.Reflection;

namespace PriceParser.Application
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<ItemService>();

            return services;
        }
    }
}
