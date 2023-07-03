using MediatR;

namespace PriceParser.Application.RequestResults.Queries.GetListOfHistories
{
    public class GetListOfHistoriesQuery : IRequest<List<HistoryVm>>
    {
        public string UserId { get; set; }
    }
}
