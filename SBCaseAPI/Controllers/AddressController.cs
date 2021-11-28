using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData;
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
        
        [HttpGet]
        public IActionResult GetAddresses(ODataQueryOptions<Address> dataQueryOptions)
        {
            try
            {
                IQueryable oDataQueryable = dataQueryOptions.ApplyTo(_addressRepository.GetQueryable());
                return Ok(oDataQueryable);
            }
            catch (ODataException e)
            {
                return BadRequest(e.Message);
            }
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
