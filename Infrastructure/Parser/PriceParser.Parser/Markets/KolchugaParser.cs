using HtmlAgilityPack;
using PriceParser.Application.Interfaces;

namespace PriceParser.Parser.Markets
{
    public class KolchugaParser : BaseParser, IParser
    {
        private string baseSearchUrl = "https://www.kolchuga.ru/internet_shop/?q=";
        public async Task<List<Item>> Parsing(string query)
        {
            List<Item> result = new List<Item>();

            string html = Request(baseSearchUrl, query);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            var items = document.DocumentNode.SelectNodes(".//div[@class='catalog__list']//div[@class='catalog__item']");

            if (items != null)
            {
                foreach (var item in items)
                {
                    string name = item.SelectSingleNode(".//div[@class='catalog__item-title']//a").InnerText;

                    string priceText = item.SelectSingleNode(".//span[@class='price line_price']").InnerText;
                    priceText = priceText.Replace(" ", "");
                    priceText = priceText.Remove(priceText.Length - 3);
                    decimal price = Convert.ToDecimal(priceText);

                    string redirectUrl = "https://www.kolchuga.ru" + item.SelectSingleNode(".//div[@class='catalog__item-title']//a").Attributes["href"].Value;

                    result.Add(new Item(name, price, "Кольчуга", redirectUrl));
                }
            }
            return result;
        }
    }
}
