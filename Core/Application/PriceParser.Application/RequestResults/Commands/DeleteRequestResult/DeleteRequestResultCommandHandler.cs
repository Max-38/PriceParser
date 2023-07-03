using MediatR;
using PriceParser.Application.Interfaces;

namespace PriceParser.Application.RequestResults.Commands.DeleteRequestResult
{
    public class DeleteRequestResultCommandHandler : IRequestHandler<DeleteRequestResultCommand>
    {
        private readonly IRequestResultRepository requestResultRepository;

        public DeleteRequestResultCommandHandler(IRequestResultRepository requestResultRepository)
        {
            this.requestResultRepository = requestResultRepository;
        }

        public async Task Handle(DeleteRequestResultCommand request, CancellationToken cancellationToken)
        {
            await requestResultRepository.Delete(request.Id);
        }
    }
}
