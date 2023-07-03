using MediatR;
using PriceParser.Application.Interfaces;

namespace PriceParser.Application.RequestResults.Commands.SaveRequestResult
{
    public class SaveRequestResultCommandHandler : IRequestHandler<SaveRequestResultCommand>
    {
        private readonly IRequestResultRepository requestResultRepository; 

        public SaveRequestResultCommandHandler(IRequestResultRepository requestResultRepository)
        {
            this.requestResultRepository = requestResultRepository;
        }

        public async Task Handle(SaveRequestResultCommand request, CancellationToken cancellationToken)
        {

            await requestResultRepository.Save(request.Result, request.UserId);
        }
    }
}
