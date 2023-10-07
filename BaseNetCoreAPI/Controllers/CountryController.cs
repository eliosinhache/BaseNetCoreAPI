using BaseNetCoreAPI.Data;
using BaseNetCoreAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BaseNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IHotelListingDbContext _context;
        public CountryController(IHotelListingDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Country> GetCountries(int id)
        {
            var result =  _context.GetCounty(id);
            if (result.Result == null)
                return NotFound();
            return result;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return  _context.GetCountries();
        }

        [HttpPost]
        public ActionResult<Country> Post(CreateCountryDto country)
        {
            var result = _context.CreateCountry(country);
            if (result.Result != null)
                return result;
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Country> Put(CreateCountryDto country)
        {
            var khe = _context.GetCounty(country.Id);
            if (khe.Result == null)
                return NotFound("CountryId not found");
            var result = _context.UpdateCountry(country);
            return Ok();
        }
    }
}
