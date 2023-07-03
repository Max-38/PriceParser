using MediatR;

namespace PriceParser.Application.RequestResults.Queries.GetHistory
{
    public class GetHistoryQuery : IRequest<RequestResultVm>
    {
        public Guid Id { get; set; }
    }
}
