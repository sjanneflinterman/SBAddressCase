using System.Threading.Tasks;
using Geolocation;
using Microsoft.AspNetCore.Mvc;
using SBData.Entities;
using SBData.Repositories;

namespace SBCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IGeolocationService _geolocationService;

        public GeolocationController(IAddressRepository addressRepository, IGeolocationService geolocationService)
        {
            _addressRepository = addressRepository;
            _geolocationService = geolocationService;
        }

        /// <summary>
        /// Get the distance in kilometers from one address to another.
        /// </summary>
        /// <param name="id1">ID of Address 1</param>
        /// <param name="id2">ID of Address 2</param>
        /// <returns></returns>
        [HttpGet("{id1},{id2}")]
        public async Task<IActionResult> Distance(int id1, int id2)
        {
            Address fromAddress = await _addressRepository.Get(id1);
            Address toAddress = await _addressRepository.Get(id2);

            if (fromAddress is null || toAddress is null)
            {
                return BadRequest();
            }

            var distance = await _geolocationService.GetDistance(fromAddress, toAddress);

            return Ok(distance);
        }
    }
}