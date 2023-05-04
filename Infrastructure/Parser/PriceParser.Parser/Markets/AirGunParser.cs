using HtmlAgilityPack;
using PriceParser.Application.Interfaces;

namespace PriceParser.Parser.Markets
{
    public class AirGunParser : BaseParser, IParser
    {
        private string baseSearchUrl = "https://www.air-gun.ru/search?find=";

        public async Task<List<Item>> Parsing(string query)
        {
            List<Item> result = new List<Item>();

            string html = Request(baseSearchUrl, query);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            var items = document.DocumentNode.SelectNodes(".//ul[@class='catalog']//li");

            if (items != null)
            {
                foreach (var item in items)
                {
                    if (item.SelectSingleNode(".//span[@class='secondary radius label']//font") != null)
                    {
                        string name = item.SelectSingleNode(".//span[@class='title']").InnerText;

                        string priceText = item.SelectSingleNode(".//div[@class='price-wrap']//span[@class='price']").InnerText;
                        priceText = priceText.Replace(" ", "");
                        priceText = priceText.Remove(priceText.Length - 4);
                        decimal price = Convert.ToDecimal(priceText);

                        string redirectUrl = item.SelectSingleNode(".//span[@class='title']//a").Attributes["href"].Value;

                        result.Add(new Item(name, price, "Air-Gun", redirectUrl));
                    }
                }
            }
            return result;
        }
    }
}
