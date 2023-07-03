namespace PriceParser.Application.Interfaces
{
    public interface IRequestResultRepository
    {
        public Task Save(RequestResult requestResult, string userId);
        public Task Delete(Guid Id);

        public Task<List<RequestResult>> GetAll(string userId);

        public Task<RequestResult> GetById(Guid Id);
    }
}
