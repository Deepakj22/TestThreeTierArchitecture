
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[Authorize(Policy = "AdminOnly")]
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _service.GetAllEmployeesAsync();
        return Ok(employees);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await _service.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound("Employee not found");
        return Ok(employee);
    }
    [HttpPost]
    public async Task<IActionResult> RegisterEmployee([FromBody]CreateEmployeeDto employee)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddEmployeeAsync(employee);
        return Ok(new { message = "Employee registered successfully" });
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveEmployee(Guid id)
    {
         await _service.DeleteEmployeeAsync(id);
        return Ok(new { message = "Employee removed successfully" });
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee(Guid id,[FromBody]UpdateEmployeeDto employee)
    {
        if (id != employee.Id)
             return BadRequest("Id mismatch");

        await _service.UpdateEmployeeAsync(employee);
        
        return Ok(new {message = "Employee updated successfully" });
    }
}
