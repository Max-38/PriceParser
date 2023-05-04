namespace PriceParser.Parser
{
    public class BaseParser
    {
        public string Request(string baseUrl, string query)
        {
            string newQuery = FormatQuery(query);
            string url = $"{baseUrl}{newQuery}";

            try
            {
                using (HttpClientHandler handler = new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.All })
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
            catch (Exception ex)
            {
                return null;
            }
        }

        private string FormatQuery(string query)
        {
            string result = query.ToLower().Replace(" ", "+");
            return result;
        }
    }
}
