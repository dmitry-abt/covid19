using Microsoft.AspNetCore.Mvc;
using CovidWatch.Repositories;
using CovidWatch.Models;

namespace CovidWatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("/countries/all")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            var data = await _countryRepository.GetAll();
            return Ok(data);
        }

        [HttpGet("/countries/best")]
        public async Task<ActionResult<IEnumerable<Country>>> GetBest()
        {
            var data = await _countryRepository.GetBest();
            return Ok(data);
        }

        [HttpGet("/countries/worse")]
        public async Task<ActionResult<IEnumerable<Country>>> GetWorse()
        {
            var data = await _countryRepository.GetWorse();
            return Ok(data);
        }
    }
}