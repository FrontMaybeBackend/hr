using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers.Employee;

[ApiController]
[Route("[controller]")]
public class EmployeeController(IEmployeeService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        var list = await service.GetEmployees();
        return Ok(list);
    }


    [HttpPost]
    public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var  result = await service.CreateEmployee(createEmployeeDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await service.DeleteEmployee(id);
        return NoContent();
    }
    
}