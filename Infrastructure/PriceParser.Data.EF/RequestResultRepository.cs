using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PriceParser.Application.Data;
using PriceParser.Application.Interfaces;

namespace PriceParser.Data.EF
{
    public class RequestResultRepository : IRequestResultRepository
    {
        private readonly IDbContextFactory<PriceParserDbContext> dbContextFactory;
        private readonly IMapper mapper;

        public RequestResultRepository(IDbContextFactory<PriceParserDbContext> dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task Save(RequestResult requestResult, string userId)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var dto = mapper.Map<RequestResultDto>(requestResult);
                dto.UserId = userId;
                await dbContext.requestResults.AddAsync(dto);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var requestResult = await dbContext.requestResults.SingleOrDefaultAsync(item => item.Id == Id);

                if (requestResult == null)
                    throw new NullReferenceException(nameof(requestResult));

                dbContext.requestResults.Remove(requestResult);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<RequestResult>> GetAll(string userId)
        {
            using(var dbContext = dbContextFactory.CreateDbContext())
            {
                var dtos = await dbContext.requestResults.Where(requestResult => requestResult.UserId == userId).ToListAsync();

                return dtos.Select(dto => mapper.Map<RequestResult>(dto)).ToList();
            }
        }

        public async Task<RequestResult> GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var dto = await dbContext.requestResults.SingleOrDefaultAsync(requestResult => requestResult.Id == id);

                if (dto == null)
                    throw new NullReferenceException(nameof(dto));

                return mapper.Map<RequestResult>(dto);
            }
        }
    }
}
