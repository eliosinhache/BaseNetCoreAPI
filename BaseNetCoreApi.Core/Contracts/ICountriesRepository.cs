using BaseNetCoreAPI.Data;

namespace BaseNetCoreAPI.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int Id);
    }
}
