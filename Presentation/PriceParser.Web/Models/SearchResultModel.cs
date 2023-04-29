namespace PriceParser.Web.Models
{
    public class SearchResultModel
    {
        public List<Position> Positions { get; set; }
        public Position BestPosition { get; set; }
    }
}
