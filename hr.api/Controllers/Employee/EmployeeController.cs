using hr.Application.Dto;
using hr.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers.Employee;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{   
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        var list = await _service.GetEmployees();
        return Ok(list);
    }


    [HttpPost]
    public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var  result = await _service.CreateEmployee(createEmployeeDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _service.DeleteEmployee(id);
        return NoContent();
    }
    
}