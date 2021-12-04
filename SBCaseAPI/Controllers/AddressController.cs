using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SBData.Entities;
using SBData.Repositories;

namespace SBCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Gets addresses with optional query functionality
        /// </summary>
        /// <remarks>
        /// Equals
        ///  /api/Address?$filter=HouseNumber eq 10
        ///
        /// Not equals
        ///  /api/Address?$filter=HouseNumber ne 10
        /// 
        /// Contains
        ///  /api/Address?$filter=contains(Country, 'land')
        /// 
        /// OrderBy
        ///  /api/Address?$orderby=HouseNumber desc
        /// 
        /// Select
        ///  /api/Address?$select=street
        /// 
        /// </remarks>
        /// <returns></returns>
        [EnableQuery]
        [HttpGet]
        public IActionResult GetAddresses()
        {
            var result = _addressRepository.GetQueryable();
            return Ok(result);
        }

        /// <summary>
        /// Get one address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            return await _addressRepository.Get(id);
        }

        /// <summary>
        /// Add an address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress([FromBody] Address address)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newAddress = await _addressRepository.Create(address);

            return Ok(newAddress);
        }

        /// <summary>
        /// Delete an address
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteAddress(int id)
        {
            _addressRepository.Delete(id);
        }

        /// <summary>
        /// Update an address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult PutAddress([FromBody] Address address)
        {
            _addressRepository.Update(address);
            return Ok();
        }
    }
}
