using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiAzure.Models;
using RestApiAzure.Services;

namespace RestApiAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await employeeService.GetAll().ConfigureAwait(false));
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            return Ok(employeeService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee )
        {
            int id = await employeeService.Add(employee).ConfigureAwait(false);
            return CreatedAtAction(nameof(Get), new { id = id }, employee);
        }
    }
}
