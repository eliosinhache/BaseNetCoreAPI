using BaseNetCoreAPI.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace BaseNetCoreAPI.Data
{
    public interface IHotelListingDbContext
    {
        ActionResult<IEnumerable<Country>> GetCountries();
        Country GetCounty(int id);
        ActionResult<Country> CreateCountry(Country country);
        ActionResult<Country> UpdateCountry(Country country);
    }
}
