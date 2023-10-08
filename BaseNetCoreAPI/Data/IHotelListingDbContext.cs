using BaseNetCoreAPI.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace BaseNetCoreAPI.Data
{
    public interface IHotelListingDbContext
    {
        IEnumerable<Country> GetCountries();
        Country GetCounty(int id);
        Country CreateCountry(Country country);
        Country UpdateCountry(Country country);
        //Task<List<T>> GetCountries();
        //Task<T> GetCounty(int id);
        //Task<T> CreateCountry(Country country);
        //Task<T> UpdateCountry(Country country);
    }
}
