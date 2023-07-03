using AutoMapper;
using PriceParser.Application.Mappings;

namespace PriceParser.Application.RequestResults.Queries.GetListOfHistories
{
    public class HistoryVm : IMapWith<RequestResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequestResult, HistoryVm>()
                   .ForMember(historyVm => historyVm.Id, opt => opt.MapFrom(RequestResult => RequestResult.Id))
                   .ForMember(historyVm => historyVm.Name, opt => opt.MapFrom(RequestResult => RequestResult.Query))
                   .ForMember(historyVm => historyVm.Date, opt => opt.MapFrom(requestResult => requestResult.Date));
        }
    }
}
