using MediatR;

namespace PriceParser.Application.RequestResults.Commands.SaveRequestResult
{
    public class SaveRequestResultCommand : IRequest
    {
        public RequestResult Result { get; set; }
        public string UserId { get; set; }
    }
}
