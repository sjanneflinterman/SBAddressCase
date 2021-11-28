using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBData.Entities;
using SBData.Repositories;

namespace SBCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _addressRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            return await _addressRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress([FromBody] Address address)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newAddress = await _addressRepository.Create(address);
            return Ok();
        }

        [HttpDelete]
        public void DeleteAddress(int id)
        {
            _addressRepository.Delete(id);
        }

        [HttpPut]
        public ActionResult PutAddress([FromBody] Address address)
        {
            _addressRepository.Update(address);
            return Ok();
        }
    }
}
