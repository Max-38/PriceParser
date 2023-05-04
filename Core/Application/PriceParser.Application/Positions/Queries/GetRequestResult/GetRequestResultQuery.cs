using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceParser.Application.Positions.Queries.GetRequestResult
{
    public class GetRequestResultQuery : IRequest<RequestResult>
    {
        public string Query { get; set; }
    }
}
