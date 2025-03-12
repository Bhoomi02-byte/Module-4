using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module_4.Data;
using Module_4.DTO;
using Module_4.Models.Entities;
using Module_4.Services;


namespace Module_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public employeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("get-details/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployees(Employee employee)
        {
           await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("update/{id}")]
        public async Task< IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeedto updateEmployeeDto)
        {
            try
            {
               await _employeeService.UpdateEmployee(id, updateEmployeeDto);
                return Ok(new { message = "Employee updated successfully" });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            try
            {
                await _employeeService.DeleteEmployee(id);

                return Ok(new { message = "Employee deleted sucessfully " });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
