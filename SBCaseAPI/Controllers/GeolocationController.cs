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

        [HttpGet("{id1},{id2}")]
        public async Task<IActionResult> Distance(int id1, int id2)
        {
            Address fromAddress = await _addressRepository.Get(id1);
            Address toAddress = await _addressRepository.Get(id2);

            var distance = await _geolocationService.GetDistance(fromAddress, toAddress);

            return Ok(distance);
        }

    }
}