using AutoMapper;
using MediatR;
using PriceParser.Application.Interfaces;

namespace PriceParser.Application.RequestResults.Queries.GetListOfHistories
{
    public class GetListOfHistoriesQueryHandler : IRequestHandler<GetListOfHistoriesQuery, List<HistoryVm>>
    {
        private readonly IRequestResultRepository requestResultRepository;
        private readonly IMapper mapper;

        public GetListOfHistoriesQueryHandler(IRequestResultRepository requestResultRepository, IMapper mapper)
        {
            this.requestResultRepository = requestResultRepository;
            this.mapper = mapper;
        }

        public async Task<List<HistoryVm>> Handle(GetListOfHistoriesQuery request, CancellationToken cancellationToken)
        {
            List<HistoryVm> result = new List<HistoryVm>(); 

            var histories = await requestResultRepository.GetAll(request.UserId);

            foreach (var item in histories)
            {
                result.Add(mapper.Map<HistoryVm>(item));
            }

            return result;
        }
    }
}
