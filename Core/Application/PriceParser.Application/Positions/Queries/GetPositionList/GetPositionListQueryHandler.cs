using MediatR;
using PriceParser.Application.Interfaces;

namespace PriceParser.Application.Positions.Queries.GetPositionList
{
    public class GetPositionListQueryHandler : IRequestHandler<GetPositionListQuery, List<Position>>
    {
        private readonly IParser parser;
        
        public GetPositionListQueryHandler(IParser parser)
        {
            this.parser = parser;
        }

        public async Task<List<Position>> Handle(GetPositionListQuery request, CancellationToken cancellationToken)
        {
            List<Position> positions = new List<Position>();
            positions = parser.Parsing(request.Query);
            return positions;
        }
    }
}
