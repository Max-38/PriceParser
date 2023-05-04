using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceParser
{
    public class RequestResult
    {
        public Guid Id { get; set; }
        public List<Item> Items { get; set; }
        public List<Item> BestItems { get; set; }
        public DateTime Date { get; set; }

        public RequestResult (Guid id, List<Item> items, List<Item> bestItems, DateTime date)
        {
            Id = id;
            Items = items;
            BestItems = bestItems;
            Date = date;
        }
    }
}
