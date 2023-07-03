using MediatR;

namespace PriceParser.Application.RequestResults.Queries.GetRequestResult
{
    public class GetRequestResultQuery : IRequest<RequestResult>
    {
        public string Query { get; set; }
    }
}
