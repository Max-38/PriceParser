using PriceParser.Application.Interfaces;

namespace PriceParser.Application.Services
{
    public class ItemService
    {
        private readonly IParser airGunParser;
        private readonly IParser huntWorldParser;
        private readonly IParser kolchugaParser;

        public ItemService(IEnumerable<IParser> parsers)
        {
            airGunParser = parsers.FirstOrDefault(x => x.GetType().Name == "AirGunParser" || x.GetType().BaseType.Name == "AirGunParser");
            huntWorldParser = parsers.FirstOrDefault(x => x.GetType().Name == "HuntWorldParser" || x.GetType().BaseType.Name == "HuntWorldParser");
            kolchugaParser = parsers.FirstOrDefault(x => x.GetType().Name == "KolchugaParser" || x.GetType().BaseType.Name == "KolchugaParser" );
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
