using AutoMapper;
using BaseNetCoreAPI.Contracts;
using BaseNetCoreAPI.Data;
using BaseNetCoreAPI.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace BaseNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountryController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Country> GetCountries(int id)
        {
            var result = _countriesRepository.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<GetCountryDto>(result));
        }
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return  Ok(_countriesRepository.GetAllAsync());
        }

        [HttpPost]
        public ActionResult<Country> Post(CreateCountryDto country)
        {
            var Newcountry = _mapper.Map<Country>(country);
            var result = _countriesRepository.AddAsync(Newcountry);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Country> Put(CreateCountryDto country)
        {
            var updateCountry = _mapper.Map<Country>(country);
            var khe = _countriesRepository.GetAsync(updateCountry.Id);
            if (khe == null)
                return NotFound("CountryId not found");
            var result = _countriesRepository.UpdateAsync(updateCountry);
            return Ok(_mapper.Map<GetCountryDto>(result));
        }
    }
}
