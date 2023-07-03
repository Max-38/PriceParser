using PriceParser.Application.RequestResults.Commands.DeleteRequestResult;
using PriceParser.Tests.Common;

namespace PriceParser.Tests.RequestResults.Commands
{
    public class DeleteRequestResultCommandHandlerTests : BaseTest
    {
        [Fact]
        public async Task DeleteRequestResultCommandHandler_WithValidArgument_Success()
        {
            var handler = new DeleteRequestResultCommandHandler(requestResultRepository);

            await handler.Handle(new DeleteRequestResultCommand
            {
                Id = Guid.Parse("3498FD22-D299-4FD4-B424-9765F42B10FE")
            }, CancellationToken.None);

            Assert.Null(priceParserTestContextFactory.CreateDbContext().requestResults
                                            .SingleOrDefault(x => x.Id == Guid.Parse("3498FD22-D299-4FD4-B424-9765F42B10FE")));

        }

        [Fact]
        public async void DeleteRequestResultCommandHandler_WithWrongId_ThrowNullReferenceException()
        {
            var handler = new DeleteRequestResultCommandHandler(requestResultRepository);

            await Assert.ThrowsAsync<NullReferenceException>(async() =>
            {
                await handler.Handle(new DeleteRequestResultCommand
                {
                    Id = Guid.Parse("8DFA18CD-1F3E-4B6D-A24D-111111111111")
                }, CancellationToken.None);
            });
        }
    }
}
