using HtmlAgilityPack;
using PriceParser.Application.Interfaces;

namespace PriceParser.Parser
{
    public class AirGunParser : IParser
    {
        public List<Position> Parsing(string query)
        {
            List<Position> result = new List<Position>(); 
            string html = Request(query);
            //HtmlParser domParser = new HtmlParser();
            //IHtmlDocument document = domParser.ParseDocument(html);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            var positions = document.DocumentNode.SelectNodes("li");
            foreach (var item in positions)
            {
                string status = item.SelectSingleNode(".//span[@class='secondary radius label']").InnerText;
                if (status != "под заказ")
                {
                    string name = item.SelectSingleNode(".//span[@class='title']").InnerText;
                    string priceText = item.SelectSingleNode(".//div[@class='price-wrap']//span[@class='price']").InnerText;
                    decimal price = Convert.ToDecimal(priceText.Replace(" ", "").Remove(priceText.Length - 3));
                    result.Add(new Position(name, price));
                }
            }
            return result;
        }

        private string Request(string query)
        {
            string newQuery = FormatQuery(query);
            string url = $"https://www.air-gun.ru/search?find={newQuery}";

            try
            {
                using (HttpClientHandler handler = new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.All})
                {
                    using (HttpClient client = new HttpClient(handler))
                    {
                        using (HttpResponseMessage response = client.GetAsync(url).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string html = response.Content.ReadAsStringAsync().Result;
                                return html;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private string FormatQuery (string query)
        {
            string result = query.ToLower().Replace(" ", "+");
            return result;
        }
    }
}
