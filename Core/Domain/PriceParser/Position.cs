namespace PriceParser
{
    public class Position
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Position (string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
