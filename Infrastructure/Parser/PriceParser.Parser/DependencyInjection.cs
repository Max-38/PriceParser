using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Interfaces;
using PriceParser.Parser.Markets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceParser.Parser
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddParser (this IServiceCollection services)
        {
            services.AddTransient<IParser, AirGunParser>();
            services.AddTransient<IParser, HuntWorldParser>();
            services.AddTransient<IParser, KolchugaParser>();

            return services;
        }
    }
}
