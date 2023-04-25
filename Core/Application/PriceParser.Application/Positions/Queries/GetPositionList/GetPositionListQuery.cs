using MediatR;
using PriceParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceParser.Application.Positions.Queries.GetPositionList
{
    public class GetPositionListQuery : IRequest<List<Position>>
    {
        public string Query { get; set; }
    }
}
