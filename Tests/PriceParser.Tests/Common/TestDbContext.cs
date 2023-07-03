using Microsoft.EntityFrameworkCore;
using PriceParser.Application.Data;
using PriceParser.Data.EF;

namespace PriceParser.Tests.Common
{
    public static class TestDbContext
    {
        public static PriceParserDbContext testDbContext = Create();

        private static PriceParserDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PriceParserDbContext>()
                             .UseInMemoryDatabase("TestDb")
                             .Options;
            var context = new PriceParserDbContext(options);
            context.Database.EnsureCreated();

            context.requestResults.AddRange(
                    new RequestResultDto
                    {
                        Id = Guid.Parse("8DFA18CD-1F3E-4B6D-A24D-299244861028"),
                        Name = "Name1",
                        Items = new List<Item>(),
                        BestItems = new List<Item>(),
                        Date = DateTime.Now,
                        UserId = "UserAId"
                    },
                    
                    new RequestResultDto
                    {
                        Id = Guid.Parse("3498FD22-D299-4FD4-B424-9765F42B10FE"),
                        Name = "NameForDelete",
                        Items = new List<Item>(),
                        BestItems = new List<Item>(),
                        Date = DateTime.Now,
                        UserId = "UserBId"
                    }
                    );

            context.SaveChanges();
            return context;
        }
    }
}
