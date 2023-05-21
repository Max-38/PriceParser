namespace PriceParser.Application.Interfaces
{
    public interface IParser
    {
        public Task<List<Item>> Parsing(string query);
    }
}
