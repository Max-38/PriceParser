using Microsoft.EntityFrameworkCore;
using PriceParser.Data.EF;

namespace PriceParser.Tests.Common
{
    public class PriceParserTestContextFactory : IDbContextFactory<PriceParserDbContext>, IDisposable
    {

        public PriceParserDbContext context = TestDbContext.testDbContext;
        public PriceParserDbContext CreateDbContext()
        {
            return new PriceParserDbContext(new DbContextOptionsBuilder<PriceParserDbContext>()
                                                                      .UseInMemoryDatabase("TestDb")
                                                                      .Options);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
