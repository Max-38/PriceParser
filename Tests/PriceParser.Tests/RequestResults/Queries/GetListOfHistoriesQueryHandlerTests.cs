using PriceParser.Application.RequestResults.Queries.GetListOfHistories;
using PriceParser.Tests.Common;

namespace PriceParser.Tests.RequestResults.Queries
{
    public class GetListOfHistoriesQueryHandlerTests : BaseTest
    {
        [Fact]
        public async Task GetListOfHistoriesQueryHandler_WithValidArgument_Success()
        {
            var handler = new GetListOfHistoriesQueryHandler(requestResultRepository, mapper);

            var result = await handler.Handle(
                new GetListOfHistoriesQuery
                {
                    UserId = "UserAId"
                }, CancellationToken.None);

            Assert.Equal(1, result.Count);
            Assert.IsType<List<HistoryVm>>(result);
        }

        [Fact]
        public async Task GetListOfHistoriesQueryHandler_WithWrongUserId_ReturnListEmpty()
        {
            var handler = new GetListOfHistoriesQueryHandler(requestResultRepository, mapper);

            var result = await handler.Handle(
                new GetListOfHistoriesQuery
                {
                    UserId = "UserCId"
                }, CancellationToken.None);

            Assert.Empty(result);
            Assert.IsType<List<HistoryVm>>(result);
        }
    }
}
