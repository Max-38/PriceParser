using HtmlAgilityPack;
using PriceParser.Application.Interfaces;

namespace PriceParser.Parser
{
    public class AirGunParser : IParser
    {
        public async Task<List<Position>> Parsing(string query)
        {
            List<Position> result = new List<Position>(); 
            string html = Request(query);
            //HtmlParser domParser = new HtmlParser();
            //IHtmlDocument document = domParser.ParseDocument(html);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            //body//div[@class='page']//div[@class='container']//div[@class='main']//div[@class='row']//div[@class='col-md-8 col-lg-9']//ul[@class='catalog']//ul[@class='catalog']
            var positions = document.DocumentNode.SelectNodes(".//ul[@class='catalog']//li");
            foreach (var item in positions)
            {
                //string status = item.SelectSingleNode(".//span[@class='secondary radius label']//font").InnerText;
                if (item.SelectSingleNode(".//span[@class='secondary radius label']//font") != null)
                {
                    string name = item.SelectSingleNode(".//span[@class='title']").InnerText;
                    string priceText = item.SelectSingleNode(".//div[@class='price-wrap']//span[@class='price']").InnerText;
                    priceText = priceText.Replace(" ", "");
                    priceText = priceText.Remove(priceText.Length - 4);
                    decimal price = Convert.ToDecimal(priceText);
                    result.Add(new Position(new Guid(), name, price, "Air-Gun"));
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
