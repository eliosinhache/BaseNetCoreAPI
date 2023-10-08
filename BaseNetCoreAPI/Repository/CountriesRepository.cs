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

        public async Task<Country> GetDetails(int id)
        {
            var result = await _context.Country.FindAsync(id);
            return result;
            //return _context.GetCounty(id);
        }
    }
}
