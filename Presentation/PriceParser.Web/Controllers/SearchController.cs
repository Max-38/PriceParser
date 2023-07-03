using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceParser.Application.RequestResults.Queries.GetRequestResult;

namespace PriceParser.Web.Controllers
{
    [Authorize]
    public class SearchController : BaseController
    {
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
