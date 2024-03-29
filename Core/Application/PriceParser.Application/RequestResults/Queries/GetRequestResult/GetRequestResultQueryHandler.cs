﻿using MediatR;
using PriceParser.Application.Services;

namespace PriceParser.Application.RequestResults.Queries.GetRequestResult
{
    public class GetRequestResultQueryHandler : IRequestHandler<GetRequestResultQuery, RequestResult>
    {
        private readonly ItemService itemService;

        public GetRequestResultQueryHandler(ItemService itemService)
        {
            this.itemService = itemService;
        }

        public async Task<RequestResult> Handle(GetRequestResultQuery request, CancellationToken cancellationToken)
        {
            if (request.Query == null || request.Query == string.Empty)
                throw new ArgumentNullException(nameof(request.Query));

            List<Item> items = await itemService.GetItems(request.Query);

            if(items.Count != 0)
            {
                decimal minPrice = items.Min(item => item.Price);
                List<Item> bestItems = items.Where(item => item.Price == minPrice).ToList();

                RequestResult result = new RequestResult
                {
                    Id = new Guid(),
                    Items = items,
                    BestItems = bestItems,
                    Date = DateTime.Now,
                    Query = request.Query
                };
                return result;
            }
            return null;
        }
    }
}
