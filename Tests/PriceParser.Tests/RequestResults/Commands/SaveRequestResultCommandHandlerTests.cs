using Microsoft.EntityFrameworkCore;
using PriceParser.Application.RequestResults.Commands.SaveRequestResult;
using PriceParser.Tests.Common;

namespace PriceParser.Tests.RequestResults.Commands
{
    public class SaveRequestResultCommandHandlerTests : BaseTest
    {
        [Fact]
        public async Task SaveRequestResultCommandHandler_WithValidArgument_Success()
        {
            var handler = new SaveRequestResultCommandHandler(requestResultRepository);
            RequestResult requestResult = new RequestResult
            {
                Id = new Guid(),
                Items = new List<Item>(),
                BestItems = new List<Item>(),
                Date = DateTime.Now,
                Query = "New name"
            };

            await handler.Handle(new SaveRequestResultCommand
            {
                Result = requestResult,
                UserId = "UserBId"
            }, CancellationToken.None);

            Assert.NotNull(priceParserTestContextFactory.CreateDbContext().requestResults
                                               .SingleOrDefaultAsync(x => x.Id == requestResult.Id));
        }
    }
}
