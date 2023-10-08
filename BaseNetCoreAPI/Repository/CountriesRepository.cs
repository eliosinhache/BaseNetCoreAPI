using BaseNetCoreAPI.Contracts;
using BaseNetCoreAPI.Data;

namespace BaseNetCoreAPI.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public Task<Country> GetDetails(int id)
        {
            throw new NotImplementedException();
            //return _context.GetCounty(id);
        }
    }
}
