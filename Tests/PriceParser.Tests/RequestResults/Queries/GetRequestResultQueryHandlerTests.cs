using Moq;
using PriceParser.Application.Interfaces;
using PriceParser.Application.RequestResults.Queries.GetRequestResult;
using PriceParser.Application.Services;
using PriceParser.Parser.Markets;

namespace PriceParser.Tests.RequestResults.Queries
{
    public class GetRequestResultQueryHandlerTests
    {
        private ItemService CreateItemService()
        {
            var airGunParser = new Mock<AirGunParser>();
            airGunParser.As<IParser>()
                        .Setup(x => x.Parsing(It.IsAny<string>()))
                        .ReturnsAsync(new List<Item> { new Item("name1", 0, "Air-Gun", "redirectUrl") });

            var huntWorldParser = new Mock<HuntWorldParser>();
            huntWorldParser.As<IParser>()
                           .Setup(x => x.Parsing(It.IsAny<string>()))
                           .ReturnsAsync(new List<Item> { new Item("name2", 0, "Мир охоты", "redirectUrl") });

            var kolchugaParser = new Mock<KolchugaParser>();
            kolchugaParser.As<IParser>()
                          .Setup(x => x.Parsing(It.IsAny<string>()))
                          .ReturnsAsync(new List<Item> { new Item("name3", 0, "Кольчуга", "redirectUrl") });

            

            IEnumerable<IParser> parsers = new List<IParser>
            {
                airGunParser.Object,
                huntWorldParser.Object,
                kolchugaParser.Object,
            };

            return new ItemService(parsers);
        }

        [Fact]
        public async Task GetRequestResultQueryHandler_WithValidQuery_ReturnList()
        {
            string query = "query";

            var handler = new GetRequestResultQueryHandler(CreateItemService());

            var result = await handler.Handle(
                new GetRequestResultQuery
                {
                    Query = query
                }, CancellationToken.None);

            Assert.Equal(3, result.Items.Count);
        }

        [Fact]
        public async Task GetRequestResultQueryHandler_WithNull_ThrowArgumentNullException()
        {
            string query = null;

            var handler = new GetRequestResultQueryHandler(CreateItemService());

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var result = await handler.Handle(
                    new GetRequestResultQuery
                    {
                        Query = query
                    }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task GetRequestResultQueryHandler_WithStringEmpty_ThrowArgumentNullException()
        {
            string query = string.Empty;

            var handler = new GetRequestResultQueryHandler(CreateItemService());

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var result = await handler.Handle(
                    new GetRequestResultQuery
                    {
                        Query = query
                    }, CancellationToken.None);
            });
        }
    }
}
