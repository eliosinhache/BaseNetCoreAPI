using AutoMapper;
using BaseNetCoreAPI.Data;
using BaseNetCoreAPI.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace BaseNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IHotelListingDbContext _context;
        private readonly IMapper _mapper;
        public CountryController(IHotelListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<Country> GetCountries(int id)
        {
            var result =  _context.GetCounty(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<GetCountryDto>(result));
        }
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return  _context.GetCountries();
        }

        [HttpPost]
        public ActionResult<Country> Post(CreateCountryDto country)
        {
            var Newcountry = _mapper.Map<Country>(country);
            var result = _context.CreateCountry(Newcountry);
            if (result.Result != null)
                return result;
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Country> Put(CreateCountryDto country)
        {
            var updateCountry = _mapper.Map<Country>(country);
            var khe = _context.GetCounty(updateCountry.Id);
            if (khe == null)
                return NotFound("CountryId not found");
            var result = _context.UpdateCountry(updateCountry);
            return Ok(_mapper.Map<GetCountryDto>(result));
        }
    }
}
