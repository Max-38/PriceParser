using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceParser;

namespace PriceParser.Application.Interfaces
{
    public interface IParser
    {
        public Task<List<Position>> Parsing(string query);
    }
}
