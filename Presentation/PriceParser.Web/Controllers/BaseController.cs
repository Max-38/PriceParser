using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PriceParser.Web.Controllers
{
    public class BaseController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator =>
            mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal string UserId => User.Identity.IsAuthenticated
                                  ? User.FindFirst(ClaimTypes.NameIdentifier).Value
                                  : string.Empty;
    }
}
