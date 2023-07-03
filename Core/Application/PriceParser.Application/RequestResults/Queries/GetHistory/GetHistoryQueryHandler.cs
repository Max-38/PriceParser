using AutoMapper;
using MediatR;
using PriceParser.Application.Interfaces;

namespace PriceParser.Application.RequestResults.Queries.GetHistory
{
    public class GetHistoryQueryHandler : IRequestHandler<GetHistoryQuery, RequestResultVm>
    {
        private readonly IRequestResultRepository requestResultRepository;
        private readonly IMapper mapper;

        public GetHistoryQueryHandler (IRequestResultRepository requestResultRepository, IMapper mapper)
        {
            this.requestResultRepository = requestResultRepository;
            this.mapper = mapper;
        }

        public async Task<RequestResultVm> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
        {
            var requestResult = await requestResultRepository.GetById(request.Id);

            var result = mapper.Map<RequestResultVm>(requestResult);

            return result;
        }
    }
}
