using Microsoft.EntityFrameworkCore;

namespace BaseNetCoreAPI.Data
{
    public class HotelListingDbContext : DbContext
    {
        private List<Country> CountryDB = new List<Country>() {
            new Country(){ Id=1, Name="Argentina", ShortName="AR" },
            new Country(){ Id=2, Name="Brasil", ShortName="BR" },
            new Country(){ Id=3, Name="Uruguay", ShortName="UY" },
        };
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        //public Country CreateCountry(Country country)
        //{
        //    CountryDB.Add(country);
        //    return country;
        //}

        //public IEnumerable<Country> GetCountries()
        //{
        //    return  CountryDB;
        //}

        //public Country GetCounty(int id)
        //{
        //    var result = CountryDB.FirstOrDefault(x => x.Id == id);
        //    return result;
        //}

        //public Country UpdateCountry(Country country)
        //{
        //    var countryFinded = CountryDB.FirstOrDefault(x => x.Id == country.Id);
        //    countryFinded.Name = country.Name;
        //    countryFinded.ShortName = country.ShortName;
        //    return CountryDB.FirstOrDefault(x => x.Id == country.Id);
        //}
    }
}
