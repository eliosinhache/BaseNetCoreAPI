using BaseNetCoreAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseNetCoreAPI.Data
{
    public class HotelListingDbContext : IHotelListingDbContext
    {
        private List<Country> CountryDB = new List<Country>() {
            new Country(){ Id=1, Name="Argentina", ShortName="AR" },
            new Country(){ Id=2, Name="Brasil", ShortName="BR" },
            new Country(){ Id=3, Name="Uruguay", ShortName="UY" },
        };

        public ActionResult<Country> CreateCountry(CreateCountryDto country)
        {
            Country newCountry = new Country() { Id = country.Id, Name = country.Name, ShortName = country.ShortName };
            CountryDB.Add(newCountry);
            return new OkObjectResult(country);
        }

        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return  new OkObjectResult(CountryDB);
        }

        public ActionResult<Country> GetCounty(int id)
        {
            var result = CountryDB.FirstOrDefault(x => x.Id == id);
            return new OkObjectResult(result);
        }

        public ActionResult<Country> UpdateCountry(CreateCountryDto country)
        {
            var countryFinded = CountryDB.FirstOrDefault(x => x.Id == country.Id);
            //int index = CountryDB.IndexOf(countryFinded);
            countryFinded.Name = country.Name;
            countryFinded.ShortName = country.ShortName;
            return new OkObjectResult(CountryDB.FirstOrDefault(x => x.Id == country.Id));
        }
    }
}
