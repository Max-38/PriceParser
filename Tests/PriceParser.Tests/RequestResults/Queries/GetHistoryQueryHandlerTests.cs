using PriceParser.Application.RequestResults.Queries.GetHistory;
using PriceParser.Tests.Common;

namespace PriceParser.Tests.RequestResults.Queries
{
    public class GetHistoryQueryHandlerTests : BaseTest
    {
        [Fact]
        public async Task GetHistoryQueryHandler_WithValidArgument_Success()
        {
            var handler = new GetHistoryQueryHandler(requestResultRepository, mapper);

            var result = await handler.Handle(
                new GetHistoryQuery
                {
                    Id = Guid.Parse("8DFA18CD-1F3E-4B6D-A24D-299244861028")
                }, CancellationToken.None);

            Assert.IsType<RequestResultVm>(result);
            Assert.NotNull(result.BestItems);
        }

        [Fact]
        public async Task GetHistoryQueryHandler_WithWrongId_ThrowNullReferenceException()
        {
            var handler = new GetHistoryQueryHandler(requestResultRepository, mapper);

            await Assert.ThrowsAsync<NullReferenceException>( async() =>
            {
                RequestResultVm result = await handler.Handle(
                   new GetHistoryQuery
                   {
                       Id = Guid.Parse("8DFA18CD-1F3E-4B6D-A24D-111111111111")
                   }, CancellationToken.None);
            });
        }
    }
}
