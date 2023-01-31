using Microsoft.AspNetCore.Mvc;
using PROJ.API.Models;
using PROJ.API.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;

        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());

            //            return Ok(Task.FromResult(new string[] { "value1", "value2" }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) { return NotFound($"{id} not found"); }
            else if (id < 0) { return BadRequest("Wrong data"); }
            return Ok(await _employeeSvc.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var createdEmployee = await _employeeSvc.Create(employee);
            var routeValue = new { id = createdEmployee.Id };
            return CreatedAtRoute(routeValue, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
            EmployeeModel updatedEmployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _employeeSvc.Delete(id);
            if (result) { return NoContent(); }
            return NotFound();
        }

        /*        [HttpPatch("{id}")]
                public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument employeeDocument)
                {
                    var updatedEmployee = await _employeeSvc.UpdatePatch(id, employeeDocument);
                    if (updatedEmployee == null)
                    {
                        return NotFound();
                    }
                    return Ok(updatedEmployee);
                }
        */
    }
}
