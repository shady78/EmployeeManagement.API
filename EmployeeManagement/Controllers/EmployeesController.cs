using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: /api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: /api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: /api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEmployee = await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.EmployeeID }, newEmployee);
        }

        // PUT: /api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            if (!await _employeeRepository.EmployeeExistsAsync(id))
            {
                return NotFound();
            }

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        // DELETE: /api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!await _employeeRepository.EmployeeExistsAsync(id))
            {
                return NotFound();
            }

            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
