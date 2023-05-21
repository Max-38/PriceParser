using MediatR;

namespace PriceParser.Application.Positions.Queries.GetRequestResult
{
    public class GetRequestResultQuery : IRequest<RequestResult>
    {
        public string Query { get; set; }
    }
}
