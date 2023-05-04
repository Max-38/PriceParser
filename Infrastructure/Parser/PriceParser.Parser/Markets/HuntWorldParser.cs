using HtmlAgilityPack;
using PriceParser.Application.Interfaces;

namespace PriceParser.Parser.Markets
{
    public class HuntWorldParser : BaseParser, IParser
    {
        private string baseSearchUrl = "https://www.huntworld.ru/search/?q=";
        public async Task<List<Item>> Parsing(string query)
        {
            List<Item> result = new List<Item>();

            string html = Request(baseSearchUrl, query);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            var items = document.DocumentNode.SelectNodes(".//div[@class='cards table-view']//div[@class='card-container']");

            if (items != null)
            {
                foreach (var item in items)
                {
                    string status = item.SelectSingleNode(".//div[@class='product-preview__buy']").InnerText;

                    if (status == "В корзину")
                    {
                        string name = item.SelectSingleNode(".//a[@class='product-preview__name no-link']").InnerText;

                        string priceText = item.SelectSingleNode(".//span[@class='price-num']").InnerText;
                        priceText = priceText.Replace(" ", "");
                        decimal price = Convert.ToDecimal(priceText);

                        string redirectUrl = "https://www.huntworld.ru" + item.SelectSingleNode(".//a[@class='product-preview__name no-link']").Attributes["href"].Value;

                        result.Add(new Item(name, price, "Мир охоты", redirectUrl));
                    }
                }
            }
            return result;
        }
    }
}
