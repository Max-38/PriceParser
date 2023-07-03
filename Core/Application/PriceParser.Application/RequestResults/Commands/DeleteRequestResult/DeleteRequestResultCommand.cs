using MediatR;

namespace PriceParser.Application.RequestResults.Commands.DeleteRequestResult
{
    public class DeleteRequestResultCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
