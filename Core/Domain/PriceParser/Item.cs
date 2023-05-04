namespace PriceParser
{
    public class Item
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Market { get; }
        public string RedirectUrl { get; }

        public Item (string name, decimal price, string market, string redirectUrl)
        {
            Name = name;
            Price = price;
            Market = market;
            RedirectUrl = redirectUrl;
        }
    }
}
