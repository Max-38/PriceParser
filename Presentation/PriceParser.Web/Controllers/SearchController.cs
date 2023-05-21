using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceParser.Application.Positions.Queries.GetRequestResult;

namespace PriceParser.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator =>
            mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> Index(string query)
        {
            GetRequestResultQuery search = new GetRequestResultQuery
            {
                Query = query
            };

            var result = await Mediator.Send(search);

            return View(result);
        }
    }
}
