using AutoMapper;
using PriceParser.Application.Mappings;

namespace PriceParser.Application.RequestResults.Queries.GetHistory
{
    public class RequestResultVm : IMapWith<RequestResult>
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public List<Item> BestItems { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequestResult, RequestResultVm>()
                   .ForMember(requestResultVm => requestResultVm.Name, opt => opt.MapFrom(RequestResult => RequestResult.Query))
                   .ForMember(requestResultVm => requestResultVm.Items, opt => opt.MapFrom(RequestResult => RequestResult.Items))
                   .ForMember(requestResultVm => requestResultVm.BestItems, opt => opt.MapFrom(RequestResult => RequestResult.BestItems))
                   .ForMember(requestResultVm => requestResultVm.Date, opt => opt.MapFrom(requestResult => requestResult.Date));
        }
    }
}
