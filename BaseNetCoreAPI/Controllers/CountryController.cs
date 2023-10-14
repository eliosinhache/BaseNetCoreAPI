using AutoMapper;
using BaseNetCoreAPI.Contracts;
using BaseNetCoreAPI.Data;
using BaseNetCoreAPI.Exceptions;
using BaseNetCoreAPI.Models;
using BaseNetCoreAPI.Models.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var result = await _countriesRepository.GetDetails(id);
            if (result == null)
                //return NotFound();
                throw new NotFoundException(nameof(GetCountry), id);
            return Ok(_mapper.Map<GetCountryDto>(result));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return  Ok(records);
        }

        [HttpGet]
        //GET: api/countries/?StartIndex=0&Pagesize=2&PageNumber=1
        public async Task<ActionResult<PageResult<GetCountryDto>>> GetPagedCountries(
            [FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _countriesRepository.GetAllAsync<GetCountryDto>(queryParameters);
            //var records = _mapper.Map<List<GetCountryDto>>(countries);
            return  Ok(pagedCountriesResult);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Post(CreateCountryDto country)
        {
            var Newcountry = _mapper.Map<Country>(country);
            await _countriesRepository.AddAsync(Newcountry);
            return CreatedAtAction("GetCountry", new { id = Newcountry.Id });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }


        [HttpPut]
        public async Task<ActionResult<Country>> Put(UpdateCountryDto country)
        {
            var updateCountry = _mapper.Map<Country>(country);
            try
            {
                await _countriesRepository.UpdateAsync(updateCountry);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(country.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
