namespace PriceParser
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Market { get; set; }

        public Position (Guid id, string name, decimal price, string market)
        {
            Id = id;
            Name = name;
            Price = price;
            Market = market;
        }
    }
}
