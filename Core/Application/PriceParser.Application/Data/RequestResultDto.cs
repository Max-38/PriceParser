using AutoMapper;
using PriceParser.Application.Mappings;

namespace PriceParser.Application.Data
{
    public class RequestResultDto : IMapWith<RequestResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public List<Item> BestItems { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequestResult, RequestResultDto>()
                   .ForMember(requestResultDto => requestResultDto.Id, opt => opt.MapFrom(requestResult => requestResult.Id))
                   .ForMember(requestResultDto => requestResultDto.Name, opt => opt.MapFrom(requestResult => requestResult.Query))
                   .ForMember(requestResultDto => requestResultDto.Items, opt => opt.MapFrom(requestResult => requestResult.Items))
                   .ForMember(requestResultDto => requestResultDto.BestItems, opt => opt.MapFrom(RequestResult => RequestResult.BestItems))
                   .ForMember(requestResultDto => requestResultDto.Date, opt => opt.MapFrom(requestResult => requestResult.Date));

            profile.CreateMap<RequestResultDto, RequestResult>()
                   .ForMember(requestResult => requestResult.Id, opt => opt.MapFrom(requestResultDto => requestResultDto.Id))
                   .ForMember(requestResult => requestResult.Query, opt => opt.MapFrom(requestResultDto => requestResultDto.Name))
                   .ForMember(requestResult => requestResult.Items, opt => opt.MapFrom(requestResultDto => requestResultDto.Items))
                   .ForMember(requestResult => requestResult.BestItems, opt => opt.MapFrom(requestResultDto => requestResultDto.BestItems))
                   .ForMember(requestResult => requestResult.Date, opt => opt.MapFrom(requestResultDto => requestResultDto.Date));
        }
    }
}
