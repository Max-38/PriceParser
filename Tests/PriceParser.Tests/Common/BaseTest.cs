using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PriceParser.Application.Interfaces;
using PriceParser.Application.Mappings;
using PriceParser.Data.EF;

namespace PriceParser.Tests.Common
{
    public class BaseTest
    {
        protected readonly IDbContextFactory<PriceParserDbContext> priceParserTestContextFactory = new PriceParserTestContextFactory();
        protected readonly IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(
                typeof(IRequestResultRepository).Assembly));
        }).CreateMapper();

        protected readonly IRequestResultRepository requestResultRepository;
        public BaseTest()
        {
            requestResultRepository = new RequestResultRepository(priceParserTestContextFactory, mapper);
        }
    }
}
