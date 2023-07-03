using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriceParser.Application.RequestResults.Commands.DeleteRequestResult;
using PriceParser.Application.RequestResults.Commands.SaveRequestResult;
using PriceParser.Application.RequestResults.Queries.GetHistory;
using PriceParser.Application.RequestResults.Queries.GetListOfHistories;

namespace PriceParser.Web.Controllers
{
    [Authorize]
    public class HistoryController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GetListOfHistoriesQuery query = new GetListOfHistoriesQuery
            {
                UserId = UserId
            };

            var result = await Mediator.Send(query);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory(Guid id)
        {
            GetHistoryQuery query = new GetHistoryQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Guid id, List<string> itemsJson, List<string> bestItemsJson, DateTime date, string query)
        {
            List<Item> bestItems = new List<Item>();
            foreach(string item in bestItemsJson)
            {
                bestItems.Add(JsonConvert.DeserializeObject<Item>(item));
            }

            List<Item> items = new List<Item>();
            foreach(string item in itemsJson)
            {
                items.Add(JsonConvert.DeserializeObject<Item>(item));
            }

            RequestResult result = new RequestResult
            {
                Id = new Guid(),
                Items = items,
                BestItems = bestItems,
                Date = DateTime.Now,
                Query = query
            };

            SaveRequestResultCommand command = new SaveRequestResultCommand
            {
                Result = result,
                UserId = UserId
            };

            await Mediator.Send(command);

            TempData["Success"] = "Результат сохранен";
            return Redirect("/History/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteRequestResultCommand command = new DeleteRequestResultCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return Redirect("/History/Index");
        }
    }
}
