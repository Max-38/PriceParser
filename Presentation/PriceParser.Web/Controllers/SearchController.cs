using MediatR;
using Microsoft.AspNetCore.Mvc;
using PriceParser.Application.Positions.Queries.GetPositionList;
using PriceParser.Web.Models;

namespace PriceParser.Web.Controllers
{
    public class SearchController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator =>
            mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> Index(string query)
        {
            GetPositionListQuery search = new GetPositionListQuery
            {
                Query = query
            };

            var positions = await Mediator.Send(search);

            SearchResultModel searchResult = new SearchResultModel
            {
                Positions = positions,
                BestPosition = positions.MinBy(item => item.Price)
            };

            return View(searchResult);
        }
    }
}
