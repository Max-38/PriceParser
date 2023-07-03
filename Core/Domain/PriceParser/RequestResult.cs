namespace PriceParser
{
    public class RequestResult
    {
        public Guid Id { get; set; }
        public string Query { get; set; }
        public List<Item>? Items { get; set; }
        public List<Item> BestItems { get; set; }
        public DateTime Date { get; set; }
    }
}
