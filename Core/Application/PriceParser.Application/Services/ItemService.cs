using MediatR;
using PriceParser.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceParser.Application.Services
{
    public class ItemService
    {
        private readonly IParser airGunParser;
        private readonly IParser huntWorldParser;
        private readonly IParser kolchugaParser;

        public ItemService(IEnumerable<IParser> parsers)
        {
            airGunParser = parsers.FirstOrDefault(x => x.GetType().Name == "AirGunParser");
            huntWorldParser = parsers.FirstOrDefault(x => x.GetType().Name == "HuntWorldParser");
            kolchugaParser = parsers.FirstOrDefault(x => x.GetType().Name == "KolchugaParser");
        }

        public async Task<List<Item>> GetItems (string query)
        {
            List<Item> items = new List<Item>();

            var itemsAirGun = await airGunParser.Parsing(query);
            var itemsHuntWorld = await huntWorldParser.Parsing(query);
            var itemsKolchuga = await kolchugaParser.Parsing(query);

            items = itemsAirGun.Concat(itemsHuntWorld.Concat(itemsKolchuga)).ToList();

            return items;
        }
    }
}
