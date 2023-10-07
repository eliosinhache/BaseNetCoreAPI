using BaseNetCoreAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BaseNetCoreAPI.Data
{
    public interface IHotelListingDbContext
    {
        ActionResult<IEnumerable<Country>> GetCountries();
        ActionResult<Country> GetCounty(int id);
        ActionResult<Country> CreateCountry(CreateCountryDto country);
        ActionResult<Country> UpdateCountry(CreateCountryDto country);
    }
}
