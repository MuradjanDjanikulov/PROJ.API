using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJ.API.Models;
using PROJ.API.Services;

namespace PROJ.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;

        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) { return NotFound($"{id} not found"); }
            else if (id < 0) { return BadRequest("Wrong data"); }
            return Ok(await _addressSvc.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var createdAddress = await _addressSvc.Create(address);
            var routeValue = new { id = createdAddress.Id };
            return CreatedAtRoute(routeValue, createdAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            AddressModel updatedAddress = await _addressSvc.Update(id, address);
            return Ok(updatedAddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _addressSvc.Delete(id);
            if (result) { return NoContent(); }
            return NotFound();
        }

    }
}

